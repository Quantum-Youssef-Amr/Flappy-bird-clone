using System;
using System.Collections;
using UnityEngine;

public class GameFlowManager : MonoBehaviour
{
    [SerializeField] private CanvasGroup MainMenu, GameHUD, PauseMenu, GameOverMenu;
    [SerializeField, Tooltip("In seconds")] private float TransitionSpeed = 0.2f;
    private Coroutine _transitioning;

    public void StartGame() => GameEventHandler.Instance.OnGameStartReq?.Invoke();

    void Start()
    {
        GameEventHandler.Instance.OnGameStartReq += () => TransitionFrom(
            MainMenu,
            GameHUD,
            TransitionSpeed,
            GameEventHandler.Instance.OnGameStart);

        GameEventHandler.Instance.OnGameRestart += () => TransitionFrom(
            GameOverMenu,
            GameHUD,
            TransitionSpeed,
            GameEventHandler.Instance.OnGameStart);

        GameEventHandler.Instance.OnGamePause += () =>
        {
            if (PauseMenu.gameObject.activeSelf)

                TransitionFrom(
                    PauseMenu,
                    GameHUD,
                    TransitionSpeed,
                    GameEventHandler.Instance.OnGameStart);
            else
                TransitionFrom(
                    GameHUD,
                    PauseMenu,
                    TransitionSpeed
                );
        };

        GameEventHandler.Instance.OnGameOver += () =>
        {
            TransitionFrom(
                GameHUD,
                GameOverMenu,
                TransitionSpeed);
        };
    }

    private void TransitionFrom(CanvasGroup screen1, CanvasGroup screen2, float transitionTime, Action actionToFireWhenFinish = null)
    {
        _transitioning ??= StartCoroutine(Transition(screen1, screen2, transitionTime, actionToFireWhenFinish));
    }

    private IEnumerator Transition(CanvasGroup screen1, CanvasGroup screen2, float transitionTime, Action actionToFireWhenFinish)
    {
        yield return HideScreen(screen1, transitionTime / 2);
        MakeSureToHideScreen(screen1, 0);

        PrepareScreenToTransition(screen2);
        yield return ShowScreen(screen2, transitionTime / 2);
        MakeSureToHideScreen(screen2, 1);

        if (actionToFireWhenFinish != null)
            actionToFireWhenFinish?.Invoke();
    }

    private IEnumerator ShowScreen(CanvasGroup screen, float timeForTransition)
    {
        yield return new WaitUntil(() =>
        {
            screen.alpha = Mathf.Lerp(screen.alpha, screen.alpha + 1f / timeForTransition, Time.deltaTime * timeForTransition);
            return screen.alpha == 1;
        });
    }

    private IEnumerator HideScreen(CanvasGroup screen, float timeForTransition)
    {
        yield return new WaitUntil(() =>
        {
            screen.alpha = Mathf.Lerp(screen.alpha, screen.alpha - 1f / timeForTransition, Time.deltaTime * timeForTransition);
            return screen.alpha == 0;
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
