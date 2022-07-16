using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseManager : SingletonMonoBehaviour<PauseManager>
{
    #region Variable

    public GameObject pause;
    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    #endregion


    public bool IsPaused { get; set; }


    #region Unity lifecycle

    protected override void Awake()
    {
        base.Awake();
        if (Instance)
        {
           
            ((GameObject.Find(Objects.PauseManager)).GetComponent<PauseManager>()).pause = 
                (GameObject.Find(Objects.PauseBackground)).gameObject;
            ((GameObject.Find(Objects.PauseManager)).GetComponent<PauseManager>())._continueButton = 
                (GameObject.Find(Objects.ContinueButton)).GetComponent<Button>();
            ((GameObject.Find(Objects.PauseManager)).GetComponent<PauseManager>())._restartButton = 
                (GameObject.Find(Objects.RestartButton)).GetComponent<Button>();
            ((GameObject.Find(Objects.PauseManager)).GetComponent<PauseManager>())._exitButton = 
                (GameObject.Find(Objects.ExitButton)).GetComponent<Button>();


            // (FindObjectOfType<Button>(name == Objects.ContinueButton));




            // (GameObject.Find(Objects.PauseManager)).GetComponent<PauseManager>())._continueButton = ((GameObject.Find(Objects.ContinueButton)).gameObject);
        }
       
        _restartButton.onClick.AddListener(delegate { GameManager.Instance.ReloadScene(); });
       
    }

  
    private void Update()
    { _continueButton.onClick.AddListener(TogglePause);
        _exitButton.onClick.AddListener(ExitGame);
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();

        pause.SetActive(IsPaused);
        Debug.Log($"timeScale {Time.timeScale}");
    }

    #endregion


    #region Private methods

    private void TogglePause()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0 : 1;
    }

    private void RestartLevel()
    {
       SceneLoader.ReloadCurrentScene();
       IsPaused = false;
    }
    
    private void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    

    #endregion
}