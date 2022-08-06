using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Variable

    private Ball _ball;

    private int _lifes;
    private bool _isStarted;
    private bool _isGameOver;

    #endregion


    #region Properties

    public int Lifes { get; set; }

    #endregion


    #region Events

    public event Action<int> OnLifeChanged;
    public event Action<bool> OnGameOver;

    #endregion


    #region Unity lifecycle

    protected override void Awake()
    {
        base.Awake();
        _ball = FindObjectOfType<Ball>();
    }

    private void Start()
    {
        _lifes = Lifes;
    }

    private void Update()
    {
        Win();
        if (_ball == null)
            _ball = FindObjectOfType<Ball>();
        if (_isStarted || _isGameOver)
            return;

        ReturnBallAndPad();
    }

    #endregion


    #region Private methods

    private void ReturnBallAndPad()
    {
        _ball.MoveWithPad();
        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }
    }

    private void StartBall()
    {
        _isStarted = true;
        PauseManager.Instance.ResumeTime();
        _ball.StartMove();
    }

    private void Win()
    {
        if (SceneManager.GetActiveScene().name == Objects.WinScene)
        {
            GameObject.FindWithTag(Objects.GameManager).SetActive(false);
            GameObject.FindWithTag(Objects.PauseManager).SetActive(false);
        }
        else if (GameObject.FindWithTag(Objects.DestructibleBlock) == null)
        {
            SceneLoader.Instance.LoadNextScene();
            _isStarted = false;
        }
    }

    #endregion


    #region Public methods

    public void ReloadScene()
    {
        SceneLoader.Instance.ReloadCurrentScene();
        _isStarted = false;
        ScoreManager.Instance.ResetScore();
        PauseManager.Instance.ResumeTime();
    }

    public void RestartGame()
    {
        SceneLoader.LoadScene(Objects.FirstSceneLevel);
        _isStarted = false;
        _isGameOver = false;
        ScoreManager.Instance.ResetScore();
        //PauseManager.Instance.OnPause?.Invoke(false);
        //GameObject.FindWithTag(Objects.GameManager).SetActive(true);
        //GameObject.FindWithTag(Objects.PauseManager).SetActive(true);
    }

    public void GameOver()
    {
        _lifes--;
        PauseManager.Instance.StopTime();
        if (_lifes != 0)
        {
            OnLifeChanged?.Invoke(_lifes);
            _isStarted = false;
            _ball.RestartPosition();
        }
        else
        {
            _lifes = Lifes;
            _isGameOver = true;
            OnGameOver?.Invoke(true);
        }
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    #endregion
}