using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    #region Variables

    [SerializeField] private TextMeshProUGUI _gameOverScore;
    [SerializeField] private Button _restartGameButton;
    [SerializeField] private Button _exitGameButton;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        _restartGameButton.onClick.AddListener(delegate { GameManager.Instance.RestartGame(); });
        _exitGameButton.onClick.AddListener(delegate { GameManager.Instance.ExitGame(); });
    }

    private void Update()
    {
        _gameOverScore.text = $"Score: {ScoreManager.Score.ToString()}";
    }

    #endregion
}