using UnityEngine;

public class GameScreen : MonoBehaviour
{
    #region Variables

    [SerializeField] private GameObject[] _allLifes;
    public GameObject gameOver;

    #endregion


    private void Awake()
    {
        gameOver.SetActive(false);
    }

    private void Start()
    {
        GameManager.Instance.Lifes = _allLifes.Length;

        GameManager.Instance.OnLifeChanged += LifeChanged;
        GameManager.Instance.OnGameOver += GameOver;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnLifeChanged -= LifeChanged;
        GameManager.Instance.OnGameOver -= GameOver;
    }

    private void GameOver(bool isGameOver)
    {
        gameOver.SetActive(isGameOver);
    }

    private void LifeChanged(int life)
    {
        Destroy(_allLifes[life]);
    }
}