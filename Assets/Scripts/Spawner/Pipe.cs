using System.Collections;
using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float MovingSpeed;
    [SerializeField] private float RemoveAfter = 10f;
    private Rigidbody2D _rb;
    private Transform _t;
    private bool _disableMovement;

    void Start()
    {
        _t = transform;
        _rb = GetComponent<Rigidbody2D>();
        StartCoroutine(RemovePipe());

        GameEventHandler.Instance.OnGamePause += () => StopAllCoroutines();
        GameEventHandler.Instance.OnGameContinue += () => StartCoroutine(RemovePipe());
    }

    void FixedUpdate()
    {
        if (_disableMovement)
        {
            _rb.linearVelocity = Vector2.zero;
            return;
        }
        _rb.AddForce(_t.position + MovingSpeed * Time.deltaTime * Vector3.left, ForceMode2D.Force);
    }

    private IEnumerator RemovePipe()
    {
        yield return new WaitForSeconds(RemoveAfter);
        Destroy(gameObject);
    }

    public void SetMovementMode(bool state)
    {
        _disableMovement = !state;
    }
}
