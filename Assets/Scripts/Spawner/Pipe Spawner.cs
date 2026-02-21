using UnityEngine;
using System.Collections;


public class PipeSpawner : MonoBehaviour
{
    [SerializeField] private int Rate;
    [SerializeField] private GameObject Pipe;

    private Transform _t;
    private Coroutine _pipeSpawner;

    void Start()
    {
        _t = transform;

        GameEventHandler.Instance.OnGameStart += () =>
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

        float m_randomYpos = Random.Range(-5f, 6f);
        Instantiate(Pipe, new(_t.position.x, m_randomYpos), Quaternion.identity, _t);

        _pipeSpawner = null;
        _pipeSpawner ??= StartCoroutine(SpawnPipe());
    }
}
