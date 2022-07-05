using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _speed;

    private float horizontalInput;
    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        transform.position += new Vector3(0, 0, _speed * Time.deltaTime);
    }

    public void Move()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        Vector3 moveHorizontal = transform.right * horizontalInput * _moveSpeed * Time.deltaTime;
        _rigidbody.MovePosition(_rigidbody.position + moveHorizontal);
    }
}
