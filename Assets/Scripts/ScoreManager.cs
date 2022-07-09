using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    #region Veriables

    [SerializeField] private TextMeshProUGUI _currentScore;
    private int _counterScore;

    #endregion


    protected override void Awake()
    {
        base.Awake();
        if (Instance)
        {
            ((GameObject.Find(Objects.ScoreCounter)).GetComponent<ScoreManager>())._currentScore =
                (GameObject.Find(Objects.ScoreText)).GetComponent<TextMeshProUGUI>();
        }

    }


    #region Public methods

    public void Counter(int score)
    {
        _counterScore += score;
        
            _currentScore.text = _counterScore.ToString();
    }

    #endregion
}