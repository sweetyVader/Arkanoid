using UnityEngine;
using UnityEngine.UI;

public class WinSceneManager : MonoBehaviour
{
    #region Variable

    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    #endregion


    #region Unity lifecycle

    private void Awake()
    {
        _restartButton.onClick.AddListener(delegate { GameManager.Instance.RestartGame(); });
        _exitButton.onClick.AddListener(delegate { GameManager.Instance.ExitGame(); });
    }

    #endregion
}