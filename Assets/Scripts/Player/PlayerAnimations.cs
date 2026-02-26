using System;
using UnityEngine;

public class PlayerAnimations : MonoBehaviour
{
    private const string FLYING = "flying";
    private Animator _animator;
    void Start()
    {
        _animator = GetComponent<Animator>();

        GameEventHandler.Instance.OnGameStart += StartPlayerAnimation;
        GameEventHandler.Instance.OnGameContinue += StartPlayerAnimation;


        GameEventHandler.Instance.OnGameOver += StopPlayerAnimation;
        GameEventHandler.Instance.OnGamePause += StopPlayerAnimation;
    }

    private void StopPlayerAnimation()
    {
        _animator.SetBool(FLYING, false);
    }

    private void StartPlayerAnimation()
    {
        _animator.SetBool(FLYING, true);
    }
}
