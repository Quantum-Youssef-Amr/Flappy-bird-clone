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

        GameEventHandler.Instance.OnGameStart += () => { StartSpawning(); SetPIpesMovementState(true); };
        GameEventHandler.Instance.OnGameRestart += () => { StartSpawning(); DestroyPipes(); };
        GameEventHandler.Instance.OnGameContinue += () => { StartSpawning(); SetPIpesMovementState(true); };

        GameEventHandler.Instance.OnGamePause += () => { StopSpawning(); SetPIpesMovementState(false); };
        GameEventHandler.Instance.OnGameOver += () => { StopSpawning(); SetPIpesMovementState(false); };
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

    private void DestroyPipes()
    {
        for (int pipe = 0; pipe < _t.childCount; pipe++)
        {
            Destroy(_t.GetChild(pipe).gameObject);
        }
    }

    private void SetPIpesMovementState(bool state)
    {
        for (int pipe = 0; pipe < _t.childCount; pipe++)
        {
            _t.GetChild(pipe).GetComponent<Pipe>().SetMovementMode(state);
        }
    }
}
