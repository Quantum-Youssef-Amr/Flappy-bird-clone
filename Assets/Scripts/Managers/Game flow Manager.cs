using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup MainMenu, GameHUD, PauseMenu, GameOverMenu;
    [SerializeField, Tooltip("In seconds")] private float TransitionSpeed = 0.2f;
    private Coroutine _transitioning;

    void Start()
    {
        GameEventHandler.Instance.OnGameStartReq += () =>
        {
            TransitionFrom(
            MainMenu,
            GameHUD,
            TransitionSpeed,
            GameEventHandler.Instance.OnGameStart);
        };

        GameEventHandler.Instance.OnGameRestart += () =>
        {
            TransitionFrom(
                GameOverMenu,
                GameHUD,
                TransitionSpeed,
                GameEventHandler.Instance.OnGameStart);
        };

        GameEventHandler.Instance.OnGamePause += () =>
        {
            TransitionFrom(
                GameHUD,
                PauseMenu,
                TransitionSpeed);
        };

        GameEventHandler.Instance.OnGameContinue += () =>
        {
            TransitionFrom(
                PauseMenu,
                GameHUD,
                TransitionSpeed,
                GameEventHandler.Instance.OnGameStart);
        };

        GameEventHandler.Instance.OnGameOver += () =>
        {
            TransitionFrom(
                GameHUD,
                GameOverMenu,
                TransitionSpeed);
        };
    }

    private void TransitionFrom(CanvasGroup screen1, CanvasGroup screen2, float TransitionSpeed, Action actionToFireWhenFinish = null, Action actionToFireWhenStart = null)
    {
        _transitioning ??= StartCoroutine(Transition(screen1, screen2, TransitionSpeed, actionToFireWhenFinish, actionToFireWhenStart));
    }

    private IEnumerator Transition(CanvasGroup screen1, CanvasGroup screen2, float TransitionSpeed, Action actionToFireWhenFinish, Action actionToFireWhenStart)
    {
        actionToFireWhenStart?.Invoke();

        yield return HideScreen(screen1, TransitionSpeed);
        MakeSureToHideScreen(screen1, 0);

        PrepareScreenToTransition(screen2);
        yield return ShowScreen(screen2, TransitionSpeed);
        MakeSureToHideScreen(screen2, 1);

        _transitioning = null;
        actionToFireWhenFinish?.Invoke();
    }

    private IEnumerator ShowScreen(CanvasGroup screen, float TransitionSpeed)
    {
        yield return new WaitUntil(() =>
        {
            screen.alpha = Mathf.Lerp(screen.alpha, screen.alpha + 1f, Time.deltaTime * TransitionSpeed);
            return screen.alpha >= 0.95f;
        });
    }

    private IEnumerator HideScreen(CanvasGroup screen, float TransitionSpeed)
    {
        yield return new WaitUntil(() =>
        {
            screen.alpha = Mathf.Lerp(screen.alpha, screen.alpha - 1f, Time.deltaTime * TransitionSpeed);
            return screen.alpha <= 0.05f;
        });
    }

    private void PrepareScreenToTransition(CanvasGroup screen2)
    {
        screen2.gameObject.SetActive(true);
        screen2.alpha = 0;
    }

    private void MakeSureToHideScreen(CanvasGroup screen, int alpha)
    {
        screen.alpha = alpha;
        screen.gameObject.SetActive(alpha == 1);
    }
}
