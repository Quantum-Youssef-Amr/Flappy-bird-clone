using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Pipe : MonoBehaviour
{
    [SerializeField] private float MovingSpeed;
    [SerializeField] private float RemoveAfter = 10f;
    private Rigidbody2D _rb;
    private Transform _t;

    void Start()
    {
        _t = transform;
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(RemovePipe());

        GameEventHandler.Instance.OnGamePause += () => SetRigidbodyState(isEnabled: false);
        GameEventHandler.Instance.OnGameOver += () => SetRigidbodyState(isEnabled: false);

        GameEventHandler.Instance.OnGameStart += () => SetRigidbodyState(isEnabled: true);
        GameEventHandler.Instance.OnGameContinue += () => SetRigidbodyState(isEnabled: true);

        GameEventHandler.Instance.OnGameRestart += () => DestroyPIpeNow();

    }

    private void OnDestroy()
    {
        GameEventHandler.Instance.OnGamePause -= () => SetRigidbodyState(isEnabled: false);
        GameEventHandler.Instance.OnGameOver -= () => SetRigidbodyState(isEnabled: false);

        GameEventHandler.Instance.OnGameStart -= () => SetRigidbodyState(isEnabled: true);
        GameEventHandler.Instance.OnGameContinue -= () => SetRigidbodyState(isEnabled: true);

    }

    private void SetRigidbodyState(bool isEnabled)
    {
        _rb.simulated = isEnabled;
        if (!isEnabled) StopAllCoroutines(); else StartCoroutine(RemovePipe());
    }

    void Update()
    {
        _rb.AddForce(_t.position + MovingSpeed * Time.deltaTime * Vector3.left, ForceMode2D.Force);
    }

    private IEnumerator RemovePipe()
    {
        yield return new WaitForSeconds(RemoveAfter);
        DestroyPIpeNow();
    }

    private void DestroyPIpeNow()
    {
        Destroy(gameObject);
    }
}
