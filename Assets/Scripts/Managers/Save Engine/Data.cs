using UnityEngine;

[System.Serializable]
public class Data
{
    public Settings settings;
    public int HighestScore;

    public Data()
    {
        settings = new();
        HighestScore = 0;
    }
}

[System.Serializable]
public class Settings
{
    public bool UseMusic = true;
    public bool UseSFX = true;
}