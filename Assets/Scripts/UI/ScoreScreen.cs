using TMPro;
using UnityEngine;

public class ScoreScreen : MonoBehaviour
{
    #region Variables

    [SerializeField] private TextMeshProUGUI _currentScore;

    #endregion


    #region Inity lifecycle

    private void Start()
    {
        ScoreManager.Instance.OnScoreChanged += ScoreChanged;
        UpdateLabel();
    }

    #endregion


    #region Private methods

    private void OnDestroy() =>
        ScoreManager.Instance.OnScoreChanged -= ScoreChanged;

    private void ScoreChanged(int score) =>
        UpdateLabel();

    private void UpdateLabel() =>
        _currentScore.text = ScoreManager.Instance.Score.ToString();

    #endregion
}