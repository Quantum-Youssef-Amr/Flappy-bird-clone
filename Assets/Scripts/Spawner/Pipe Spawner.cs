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

        GameEventHandler.Instance.OnGameStart += () =>
            _pipeSpawner ??= StartCoroutine(SpawnPipe());
        GameEventHandler.Instance.OnGameRestart += () =>
            _pipeSpawner ??= StartCoroutine(SpawnPipe());

        GameEventHandler.Instance.OnGameOver += () =>
        {
            if (_pipeSpawner != null)
                StopCoroutine(_pipeSpawner);
        };

        GameEventHandler.Instance.OnGamePause += () =>
        {
            if (_pipeSpawner != null)
                StopCoroutine(_pipeSpawner);
        };
    }

    private IEnumerator SpawnPipe()
    {
        yield return new WaitForSeconds(1f / Rate);

        float m_randomYpos = Random.Range(YPosBounders.x, YPosBounders.y);
        Instantiate(Pipe, new(_t.position.x, m_randomYpos), Quaternion.identity, _t);

        _pipeSpawner = null;
        _pipeSpawner ??= StartCoroutine(SpawnPipe());
    }
}
