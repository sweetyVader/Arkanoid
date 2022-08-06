using System;
using UnityEngine;

public class PauseManager : SingletonMonoBehaviour<PauseManager>
{
    #region Events

    public event Action<bool> OnPause;

    #endregion


    #region Properties

    public bool IsPaused { get; private set; }

    #endregion


    #region Unity lifecycle

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            TogglePause();
    }

    #endregion


    #region Public methods

    public void TogglePause()
    {
        IsPaused = !IsPaused;
        Time.timeScale = IsPaused ? 0 : 1;
        OnPause?.Invoke(IsPaused);
    }

    public void StopTime()
    {
        Time.timeScale = 0;
    }

    public void ResumeTime()
    {
        Time.timeScale = 1;
        IsPaused = false;
    }

    #endregion
}