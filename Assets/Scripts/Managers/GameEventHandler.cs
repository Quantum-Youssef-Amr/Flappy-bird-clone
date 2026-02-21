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
    public Action OnGameOver;

    public Action OnPlayerScore;

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
        OnGameOver = null;

        OnPlayerScore = null;
    }

}
