using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Variable

    [SerializeField] private Ball _ball;
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _gameOverScore;
    [SerializeField] private Button _restartGameButton;
    [SerializeField] private Button _exitGameButton;
    [SerializeField] private GameObject[] _allLifes;
    private int _counterScore;
    private bool _isStarted;
    private int _lifes;
    public GameObject gameOver;

    #endregion


    #region Unity lifecycle

    protected override void Awake()
    {
        base.Awake();
        if (Instance)
        {
            ((GameObject.Find(Objects.GameManager)).GetComponent<GameManager>())._ball =
                (GameObject.Find(Objects.Ball)).GetComponent<Ball>();
            ((GameObject.Find(Objects.GameManager)).GetComponent<GameManager>())._currentScore =
                (GameObject.Find(Objects.ScoreText)).GetComponent<TextMeshProUGUI>();
            ((GameObject.Find(Objects.GameManager)).GetComponent<GameManager>()).gameOver =
                (GameObject.Find(Objects.GameOverBackground)).gameObject;

            ((GameObject.Find(Objects.GameManager)).GetComponent<GameManager>())._restartGameButton =
                (GameObject.Find(Objects.RestartGameButton)).GetComponent<Button>();
            ((GameObject.Find(Objects.GameManager)).GetComponent<GameManager>())._exitGameButton =
                (GameObject.Find(Objects.ExitGameButton)).GetComponent<Button>();

            ((GameObject.Find(Objects.GameManager)).GetComponent<GameManager>())._gameOverScore =
                (GameObject.Find(Objects.ScoreGameText)).GetComponent<TextMeshProUGUI>();

            /*for (int numLife = _allLifes.Length; numLife <= 0; numLife++)
            {
                ((GameObject.Find(Objects.GameManager)).GetComponent<GameManager>())._allLifes[numLife - 1] =
                    (GameObject.Find($"heart[{numLife}]")).gameObject;
            }*/

            ((GameObject.Find(Objects.GameManager)).GetComponent<GameManager>())._allLifes[2] =
                (GameObject.Find(Objects.Heart3)).gameObject;
            ((GameObject.Find(Objects.GameManager)).GetComponent<GameManager>())._allLifes[1] =
                (GameObject.Find(Objects.Heart2)).gameObject;
            ((GameObject.Find(Objects.GameManager)).GetComponent<GameManager>())._allLifes[0] =
                (GameObject.Find(Objects.Heart1)).gameObject;
        }

        _restartGameButton.onClick.AddListener(RestartGame);
        _exitGameButton.onClick.AddListener(ExitGame);
        gameOver.SetActive(false);
        _isStarted = false;
        _lifes = _allLifes.Length;
    }

    private void Update()
    {
        if (_isStarted)
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
        _ball.StartMove();
    }

    #endregion


    #region Public methods

    public void ReloadScene()
    {
        SceneLoader.ReloadCurrentScene();
        _isStarted = false;
        _counterScore = 0;
        PauseManager.Instance.IsPaused = false;
    }

    private void RestartGame()
    {
        SceneLoader.LoadScene(Objects.FirstSceneLevel);
        _isStarted = false;
        _counterScore = 0;
        PauseManager.Instance.IsPaused = false;
    }

    public void GameOver()
    {
        _lifes--;
        if (_lifes != 0)
        {
            Destroy(_allLifes[_lifes]);

            Time.timeScale = 0;
            _isStarted = false;
            _ball.transform.position = new Vector2(0f, -4f);
        }
        else
        {
            Time.timeScale = 0;
            gameOver.SetActive(true);
            _lifes = _allLifes.Length;
            _gameOverScore.text = $"Score: {_counterScore.ToString()}";
        }
    }

    public void Counter(int score)
    {
        _counterScore += score;
        _currentScore.text = _counterScore.ToString();
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    #endregion
}