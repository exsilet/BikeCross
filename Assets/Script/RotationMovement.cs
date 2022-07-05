using RunnerMovementSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationMovement : MonoBehaviour
{
    [SerializeField] private float _zRotationAngle = 70f;
    [SerializeField] private float _rotationSpeed = 10f;
    [SerializeField] private float _returnSpeed = 5f;
    [SerializeField] private MovementSystem _movementSystem;

    private float _previousOffset;
    private float _previousXPosition;
    private Quaternion _initialRotation;

    private void Awake()
    {
        _initialRotation = transform.localRotation;
    }

    private void Update()
    {
        TryReturnToDefaultRotation();
    }

    public void TryRotateTowardsDirection(Vector3 offset)
    {
        float directionModifier = offset.x > _previousOffset ? 8f : -8f;

        RotateMesh(directionModifier, offset.x);
    }

    private void RotateMesh(float directionModifier, float xOffset)
    {
        if (_previousOffset != xOffset && _previousXPosition != _movementSystem.Offset)
        {
            _previousXPosition = _movementSystem.Offset;
            _previousOffset = xOffset;
            //_zRotationAngle* directionModifier
            Quaternion rotation = Quaternion.Euler(new Vector3(0f, 0f, _zRotationAngle * directionModifier));
            transform.localRotation = Quaternion.Lerp(transform.localRotation, rotation, _rotationSpeed * Time.deltaTime);
        }
    }

    private void TryReturnToDefaultRotation()
    {
        transform.localRotation = Quaternion.Lerp(transform.localRotation, _initialRotation, _returnSpeed * Time.deltaTime);
    }
}
