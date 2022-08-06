using System;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    #region Events

    public event Action<int> OnScoreChanged;

    #endregion


    #region Properties

    public int Score { get; private set; }

    #endregion


    #region Public methods

    public void ChangeScore(int score)
    {
        Score += score;
        OnScoreChanged?.Invoke(Score);
    }

    #endregion


    #region Public methods

    public void ResetScore()
    {
        Score = 0;
    }

    #endregion
}