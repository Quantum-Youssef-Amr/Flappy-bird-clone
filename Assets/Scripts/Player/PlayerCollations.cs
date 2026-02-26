using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private int PipeScore = 1;
    private const string PIPE = "Pipe", SCORE_AREA = "PipeScoreArea";

    void OnCollisionEnter2D(Collision2D collision)
    {
        // player Died
        if (collision.gameObject.CompareTag(PIPE))
            GameEventHandler.Instance.OnGameOver?.Invoke();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // player score
        if (collision.gameObject.CompareTag(SCORE_AREA))
            GameEventHandler.Instance.OnPlayerScore?.Invoke(PipeScore);
    }
}
