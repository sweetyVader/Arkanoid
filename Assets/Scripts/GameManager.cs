using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Variable

    private Ball _ball;

    private int _lifes = 3;
    private int _lifeBetweenScenes;
    private bool _isStarted;
    private bool _isGameOver;
    [SerializeField] private bool _needAutoPlay;

    #endregion


    #region Properties

    public bool NeedAutoPlay => _needAutoPlay;
    public int Lifes { get; private set; }

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

        Lifes = _lifeBetweenScenes == 0 ? _lifes : _lifeBetweenScenes;
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

    private void Win()
    {
        if (SceneManager.GetActiveScene().name == Objects.WinScene)
        {
            GameObject.FindWithTag(Objects.GameManager).SetActive(false);
            GameObject.FindWithTag(Objects.PauseManager).SetActive(false);
        }
        else if (GameObject.FindGameObjectWithTag(Tags.Block) == null)
        {
            _lifeBetweenScenes = Lifes;
            FindObjectOfType<Pad>().transform.localScale = Pad.Instance.StartPadSize;
            FindObjectOfType<Ball>().transform.localScale = _ball.StartBallSize;
            SceneLoader.Instance.LoadNextScene();
            _isStarted = false;
        }
    }

    #endregion


    #region Public methods

    public void ReturnBallAndPad()
    {
        _isStarted = false;
        _ball.MoveWithPad();
        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }
    }

    public void StartBall()
    {
        _isStarted = true;
        PauseManager.Instance.ResumeTime();
        _ball.StartMove();
    }

    public void ReloadScene()
    {
        SceneLoader.Instance.ReloadCurrentScene();
        _isStarted = false;
        ScoreManager.Instance.ResetScore();
        PauseManager.Instance.ResumeTime();
        GameObject.FindGameObjectWithTag(Tags.Pad).transform.localScale = Pad.Instance.StartPadSize;
    }

    public void RestartGame()
    {
        SceneLoader.LoadScene(Objects.FirstSceneLevel);
        _isStarted = false;
        _isGameOver = false;
        ScoreManager.Instance.ResetScore();
        //PauseManager.Instance.OnPause?.Invoke(false);
        GameObject.FindWithTag(Objects.GameManager).SetActive(true);
        GameObject.FindWithTag(Objects.PauseManager).SetActive(true);
        FindObjectOfType<Pad>().transform.localScale = Pad.Instance.StartPadSize;
        FindObjectOfType<Ball>().transform.localScale = _ball.StartBallSize;
    }

    public void GameOver()
    {
        Lifes--;
        PauseManager.Instance.StopTime();
        if (Lifes != 0)
        {
            OnLifeChanged?.Invoke(Lifes);
            _isStarted = false;
            _ball.RestartPosition();
        }
        else
        {
            Lifes = _lifes;
            _isGameOver = true;
            OnGameOver?.Invoke(true);
        }
    }

    public void ChangeLife(int num)
    {
        Lifes += num;
        OnLifeChanged?.Invoke(Lifes);
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    #endregion
}