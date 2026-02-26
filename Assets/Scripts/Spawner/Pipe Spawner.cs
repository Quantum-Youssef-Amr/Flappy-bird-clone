using UnityEngine;
using System.Collections;


public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private float Rate;
    [SerializeField] private GameObject Pipe;
    [SerializeField] private Vector2 YPosBounders = new(-5f, 6f);

    private Transform _t;
    private Coroutine _pipeSpawner;

    void Start()
    {
        _t = transform;

        GameEventHandler.Instance.OnGameStart += () => StartSpawning();
        GameEventHandler.Instance.OnGameRestart += () => StartSpawning();
        GameEventHandler.Instance.OnGameContinue += () => StartSpawning();

        GameEventHandler.Instance.OnGamePause += () => StopSpawning();
        GameEventHandler.Instance.OnGameOver += () => StopSpawning();
    }

    private void StartSpawning()
    {
        _pipeSpawner ??= StartCoroutine(SpawnPipe());
    }

    private void StopSpawning()
    {
        if (_pipeSpawner != null)
        {
            StopCoroutine(_pipeSpawner);
            _pipeSpawner = null;
        }
    }

    private IEnumerator SpawnPipe()
    {
        float m_randomYpos = Random.Range(YPosBounders.x, YPosBounders.y);
        Instantiate(Pipe, new(_t.position.x, m_randomYpos), Quaternion.identity, _t);

        yield return new WaitForSeconds(1f / Rate);

        _pipeSpawner = null;
        _pipeSpawner ??= StartCoroutine(SpawnPipe());
    }
}
