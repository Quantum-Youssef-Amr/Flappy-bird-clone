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
        SaveEngine.Instance.Data.settings.UseSFX = !SaveEngine.Instance.Data.settings.UseSFX;
        SetIcon();
    }

    private void SetIcon()
    {
        _btnIcon.sprite = BtnIcons[SaveEngine.Instance.Data.settings.UseSFX ? 0 : 1];
    }
}
