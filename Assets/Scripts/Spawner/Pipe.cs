using System;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float MovingSpeed;
    private Rigidbody2D _rb;
    private Transform _t;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _t = transform;

        GameEventHandler.Instance.OnGameRestart += () => { Destroy(gameObject); };
        GameEventHandler.Instance.OnGameOver += () => RB(false);
        GameEventHandler.Instance.OnGamePause += () => RB(false);

        GameEventHandler.Instance.OnGameStart += () => RB(true);
        GameEventHandler.Instance.OnGameContinue += () => RB(true);

    }

    void OnDestroy()
    {
        GameEventHandler.Instance.OnGameRestart -= () => { Destroy(gameObject); };
        GameEventHandler.Instance.OnGameOver -= () => RB(false);
        GameEventHandler.Instance.OnGamePause -= () => RB(false);

        GameEventHandler.Instance.OnGameStart -= () => RB(true);
        GameEventHandler.Instance.OnGameContinue -= () => RB(true);
    }

    private void RB(bool enable)
    {
        _rb.simulated = enable;
    }

    void Update()
    {
        _rb.AddForce(_t.position + MovingSpeed * Time.deltaTime * Vector3.left, ForceMode2D.Force);
    }
}
