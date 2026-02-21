using System;
using UnityEngine;

public class MaterialsManager : MonoBehaviour
{
    [SerializeField] private Material[] Mats;
    private const string MAT_FIELD = "_Move";

    void Start()
    {
        GameEventHandler.Instance.OnGameStart += () => ManageMat(1);
        GameEventHandler.Instance.OnGameOver += () => ManageMat(0);
        GameEventHandler.Instance.OnGamePause += () => ManageMat(0);
    }

    private void ManageMat(int state)
    {
        foreach (var Mat in Mats)
            Mat.SetInteger(MAT_FIELD, state);
    }

    void OnApplicationQuit()
    {
        ManageMat(0);
    }
}
