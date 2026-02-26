using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;
    private int _score;

    #region events
    void Start()
    {
        GameEventHandler.Instance.OnPlayerScore += score => { _score += score; UpdateScoreText(); };
        GameEventHandler.Instance.OnGameOver += () => SaveScore();
        GameEventHandler.Instance.OnGameRestart += () => SaveScore();
    }

    void OnEnable()
    {
        GameEventHandler.Instance.OnPlayerScore -= score => { _score += score; UpdateScoreText(); };
        GameEventHandler.Instance.OnGameOver -= () => SaveScore();
        GameEventHandler.Instance.OnGameRestart -= () => SaveScore();
    }

    void OnDisable()
    {
        GameEventHandler.Instance.OnPlayerScore -= score => { _score += score; UpdateScoreText(); };
        GameEventHandler.Instance.OnGameOver -= () => SaveScore();
        GameEventHandler.Instance.OnGameRestart -= () => SaveScore();
    }
    #endregion

    private void SaveScore()
    {
        SaveEngine.Instance.Data.HighestScore = Mathf.Max(SaveEngine.Instance.Data.HighestScore, _score);
    }

    private void UpdateScoreText()
    {
        ScoreText.text = _score < 10 ? $"0{_score}" : $"{_score}";
    }
}
