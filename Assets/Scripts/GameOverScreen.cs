using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    #region Variables

    [SerializeField] private TextMeshProUGUI _gameOverScore;
    [SerializeField] private Button _restartGameButton;
    [SerializeField] private Button _exitGameButton;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        _restartGameButton.onClick.AddListener(GameManager.Instance.RestartGame);
        _exitGameButton.onClick.AddListener(GameManager.Instance.ExitGame);
    }

    private void Update()
    {
        _gameOverScore.text = $"Score: {ScoreManager.Instance.Score.ToString()}";
    }

    #endregion
}