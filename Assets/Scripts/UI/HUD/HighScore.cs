using TMPro;
using UnityEngine;

public class HighScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ScoreText;

    void Start() => GameEventHandler.Instance.OnGameOver += () => UpdateScoreText();
    void OnEnable() => GameEventHandler.Instance.OnGameOver += () => UpdateScoreText();

    private void UpdateScoreText()
    {
        ScoreText.text = SaveEngine.Instance.Data.HighestScore < 10 ? $"Highest Score: 0{SaveEngine.Instance.Data.HighestScore}" : $"Highest Score: {SaveEngine.Instance.Data.HighestScore}";
    }
}
