using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    #region Variable

    [SerializeField] private Ball _ball;
    [SerializeField] private TextMeshProUGUI _currentScore;
    [SerializeField] private TextMeshProUGUI _gameOverScore;
    private int _counterScore;
    private bool _isStarted;
    
    public GameObject gameOver;
    
    #endregion


    #region Unity lifecycle

    protected override void Awake()
    {
        base.Awake();
        
        ((GameObject.Find(Objects.GameManager)).GetComponent<GameManager>())._ball =
            (GameObject.Find(Objects.Ball)).GetComponent<Ball>();
        ((GameObject.Find(Objects.GameManager)).GetComponent<GameManager>())._currentScore =
            (GameObject.Find(Objects.ScoreText)).GetComponent<TextMeshProUGUI>();
        _isStarted = false;
    }

   

    private void Update()
    {
        if (_isStarted)
            return;


        _ball.MoveWithPad();
        if (Input.GetMouseButtonDown(0))
        {
            StartBall();
        }
    }

    #endregion


    #region Private methods

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
    
    public void GameOver()
    {
        SceneLoader.ReloadCurrentScene();
        _isStarted = false;
        _counterScore = 0;
        
    }

   
    public void Counter(int score)
    {
        
        _counterScore += score;
        _currentScore.text = _counterScore.ToString();
       
    }

    #endregion
}