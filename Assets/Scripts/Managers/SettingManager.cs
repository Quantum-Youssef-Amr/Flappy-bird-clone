using UnityEngine;
using UnityEngine.Audio;

public class SettingManager : MonoBehaviour
{
    public static SettingManager Instance { get; private set; }
    [SerializeField] private AudioMixer mixer;
    private Camera _main;

    void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    void Start()
    {
        applyAudioSettings();
    }


    private void applyAudioSettings()
    {
        mixer.SetFloat("MasterVolume", SaveEngine.Instance.Data.settings.UseSFX ? 0f : -80f);

        // mixer.SetFloat("musicVolume", SaveEngine.Instance.Data.settings.UseMusic ? 0f : -80f);
    }

    public void ToggleSfxUse()
    {
        SaveEngine.Instance.Data.settings.UseSFX = !SaveEngine.Instance.Data.settings.UseSFX;
        applyAudioSettings();
    }

    // public void ToggleMusicUse()
    // {
    //     SaveEngine.Instance.Data.settings.UseMusic = !SaveEngine.Instance.Data.settings.UseMusic;
    //     applyAudioSettings();
    // }
}
