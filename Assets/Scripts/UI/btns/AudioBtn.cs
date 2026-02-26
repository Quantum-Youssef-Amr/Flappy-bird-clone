using UnityEngine;
using UnityEngine.UI;

public class AudioBtn : MonoBehaviour
{
    [SerializeField] private Sprite[] BtnIcons;
    private Image _btnIcon;

    void Start()
    {
        _btnIcon = GetComponent<Image>();
        SetIcon();
    }

    public void ToggleAudio()
    {
        SettingManager.Instance.ToggleSfxUse();
        SetIcon();
    }

    private void SetIcon()
    {
        print(SaveEngine.Instance.Data.settings.UseSFX);
        _btnIcon.sprite = BtnIcons[SaveEngine.Instance.Data.settings.UseSFX ? 0 : 1];
    }
}
