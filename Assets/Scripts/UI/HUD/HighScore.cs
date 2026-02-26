using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;

    void Start() => GameEventHandler.Instance.OnGameOver += () => UpdateScoreText();
    void OnEnable() => GameEventHandler.Instance.OnGameOver += () => UpdateScoreText();
    void OnDisable() => GameEventHandler.Instance.OnGameOver -= () => UpdateScoreText();

    private void UpdateScoreText()
    {
        ScoreText.text = $"Highest Score: {SaveEngine.Instance.Data.HighestScore}";
    }
}
