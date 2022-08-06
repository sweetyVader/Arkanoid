using UnityEngine;

public class GameScreen : MonoBehaviour
{
    #region Variables

    public GameObject gameOver;

    #endregion


    private void Awake()
    {
        gameOver.SetActive(false);
    }

    private void Start()
    {
        GameManager.Instance.OnGameOver += GameOver;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnGameOver -= GameOver;
    }

    private void GameOver(bool isGameOver)
    {
        gameOver.SetActive(isGameOver);
    }
}