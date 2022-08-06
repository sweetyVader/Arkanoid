using UnityEngine;
using UnityEngine.UI;

public class WinScreen : MonoBehaviour
{
    #region Variable

    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        _restartButton.onClick.AddListener(GameManager.Instance.RestartGame);
        _exitButton.onClick.AddListener(GameManager.Instance.ExitGame);
    }

    #endregion
}