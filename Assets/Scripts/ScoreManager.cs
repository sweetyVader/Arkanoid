using TMPro;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    #region Variables

    [SerializeField] private TextMeshProUGUI _currentScore;

    #endregion


    #region Properties

    public static int Score { get; set; }

    #endregion


    #region Unity lifecycle

    protected override void Awake()
    {
        base.Awake();
        DontDestroyOnLoad(gameObject);
        if (Score != 0)
            DontDestroyOnLoad(gameObject);
        ((GameObject.Find(Objects.ScoreManager)).GetComponent<ScoreManager>())._currentScore =
            (GameObject.Find(Objects.ScoreText)).GetComponent<TextMeshProUGUI>();
    }

    private void Update()
    {
        _currentScore.text = Score.ToString();
    }

    #endregion


    #region Public methods

    public void Counter(int score)
    {
        Score += score;
    }

    #endregion
}