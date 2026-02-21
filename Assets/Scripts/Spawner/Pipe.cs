using UnityEngine;

public class Pipe : MonoBehaviour
{
    [SerializeField] private float MovingSpeed;
    private Rigidbody2D _rb;
    private Transform _t;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _t = transform;
    }

    void Update()
    {
        _rb.MovePosition(_t.position + MovingSpeed * Vector3.left);
    }
}
