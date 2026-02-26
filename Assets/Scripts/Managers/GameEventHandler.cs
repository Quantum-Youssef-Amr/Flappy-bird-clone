using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class GameEventHandler : MonoBehaviour
{
    public static GameEventHandler Instance { get; private set; }
    public Action OnGameStartReq;
    public Action OnGameStart;
    public Action OnGameRestart;
    public Action OnGamePause;
    public Action OnGameContinue;
    public Action OnGameOver;

    public Action<int> OnPlayerScore;

    void Awake()
    {
        if (Instance == null)
            Instance = this;

        SceneManager.activeSceneChanged += (_, _) => FreeOldReferences();
    }

    private void FreeOldReferences()
    {
        OnGameStartReq = null;
        OnGameStart = null;
        OnGameRestart = null;
        OnGamePause = null;
        OnGameContinue = null;
        OnGameOver = null;

        OnPlayerScore = null;
    }

}
