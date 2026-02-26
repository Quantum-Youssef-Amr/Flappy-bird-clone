using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float JumpForce, RotationSpeed;
    [SerializeField] private Vector2 BirdAngleBounds;

    private inputSystem _inputs;
    private Rigidbody2D _rb;
    private Transform _t;
    private Vector2 _startPos;

    void Awake()
    {
        _inputs = new();
    }

    void OnEnable() => _inputs.Enable();
    void OnDisable() => _inputs.Disable();


    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _t = transform;
        _startPos = _t.position;
        _inputs.Player.Jump.performed += Jump;

        GameEventHandler.Instance.OnGameStart += TurnOnPlayerPhysics;
        GameEventHandler.Instance.OnGameContinue += TurnOnPlayerPhysics;

        GameEventHandler.Instance.OnGameOver += TurnOffPlayerPhysics;
        GameEventHandler.Instance.OnGamePause += TurnOffPlayerPhysics;

        GameEventHandler.Instance.OnGameRestart += () => resetPlayerPos();
    }

    private void resetPlayerPos()
    {
        _t.SetPositionAndRotation(_startPos, Quaternion.identity);
    }

    private void TurnOffPlayerPhysics()
    {
        _rb.simulated = false;
    }

    private void TurnOnPlayerPhysics()
    {
        _rb.simulated = true;
    }

    private void Jump(InputAction.CallbackContext context)
    {
        if (!_rb.simulated) return;

        _rb.linearVelocity = Vector2.zero;
        _rb.AddForce(JumpForce * Vector2.up, ForceMode2D.Impulse);
    }

    void Update()
    {
        if (!_rb.simulated) return;

        _t.rotation = Quaternion.Lerp(
            _t.rotation,
            Quaternion.Euler(0, 0, Mathf.Clamp(Vector2.SignedAngle(Vector2.right, _rb.linearVelocity), BirdAngleBounds.x, BirdAngleBounds.y)),
            Time.deltaTime * RotationSpeed);
    }
}
