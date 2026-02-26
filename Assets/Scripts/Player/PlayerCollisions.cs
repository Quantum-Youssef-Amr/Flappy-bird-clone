using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    [SerializeField] private int PipeScore = 1;
    [SerializeField] private AudioClip ScoreSound, DeathSound;
    private const string PIPE = "Pipe", GROUND = "ground", SCORE_AREA = "PipeScoreArea";


    void OnCollisionEnter2D(Collision2D collision)
    {
        // player Died
        if (collision.gameObject.CompareTag(PIPE) || collision.gameObject.CompareTag(GROUND))
        {
            GameEventHandler.Instance.OnGameOver?.Invoke();
            AudioManager.Instance.PlayerSfx(DeathSound);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // player score
        if (collision.gameObject.CompareTag(SCORE_AREA))
        {
            GameEventHandler.Instance.OnPlayerScore?.Invoke(PipeScore);
            AudioManager.Instance.PlayerSfx(ScoreSound);
        }
    }
}
