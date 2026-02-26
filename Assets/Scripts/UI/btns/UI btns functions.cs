using UnityEngine;

public class UIBtnsFunctions : MonoBehaviour
{
    public void OnStartGame() => GameEventHandler.Instance.OnGameStartReq?.Invoke();
    public void OnPauseToggle() => GameEventHandler.Instance.OnGamePause?.Invoke();
    public void OnContinueToggle() => GameEventHandler.Instance.OnGameContinue?.Invoke();
    public void OnRestartToggle() => GameEventHandler.Instance.OnGameRestart?.Invoke();
    public void OnQuitToggle() => Application.Quit();
}
