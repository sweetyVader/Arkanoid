using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Variable

    [SerializeField] private Ball _ball;

    [SerializeField] private GameObject[] _allLifes;

    private bool _isStarted;
    private int _lifes;
    public GameObject gameOver;

    #endregion


    #region Unity lifecycle

    protected override void Awake()
    {
        base.Awake();
        //DontDestroyOnLoad(_lifes);
        if (Instance)
        {
            ((GameObject.Find(Objects.GameManager)).GetComponent<GameManager>())._ball =
                (GameObject.Find(Objects.Ball)).GetComponent<Ball>();

            ((GameObject.Find(Objects.GameManager)).GetComponent<GameManager>()).gameOver =
                (GameObject.Find(Objects.GameOverBackground)).gameObject;


            /*for (int numLife = _lifes; numLife <= 0; numLife++)
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


        gameOver.SetActive(false);

        _lifes = _allLifes.Length;
    }

    private void Update()
    {
        Win();

        Debug.Log($"is started {_isStarted}");
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
        ScoreManager.Score = 0;
        PauseManager.Instance.IsPaused = false;
    }

    public void RestartGame()
    {
        SceneLoader.LoadScene(Objects.FirstSceneLevel);
        _isStarted = false;
        ScoreManager.Score = 0;
        PauseManager.Instance.IsPaused = false;
        GameObject.FindWithTag(Objects.GameManager).SetActive(true);
        GameObject.FindWithTag(Objects.PauseManager).SetActive(true);
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
        }
    }

    public void ExitGame()
    {
        UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
    }

    #endregion
}