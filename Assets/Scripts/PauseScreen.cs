using UnityEngine;
using UnityEngine.UI;

public class PauseScreen : MonoBehaviour
{
    #region Variables

    public GameObject pause;

    [SerializeField] private Button _continueButton;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;

    #endregion


    #region Unite lifecycle

    private void Start()
    {
        pause.SetActive(false);
        _continueButton.onClick.AddListener(PauseManager.Instance.TogglePause);
        _restartButton.onClick.AddListener(GameManager.Instance.ReloadScene);
        _exitButton.onClick.AddListener(GameManager.Instance.ExitGame);
        PauseManager.Instance.OnPause += PauseSwitch;
    }

    private void OnDestroy() =>
        PauseManager.Instance.OnPause -= PauseSwitch;

    private void PauseSwitch(bool isPause)
    {
        pause.SetActive(isPause);
    }

    #endregion
}