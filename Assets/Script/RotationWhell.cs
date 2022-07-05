using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationWhell : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.Rotate(-2,0,0);
    }

    public void RotationWeels(float vect)
    {
        Quaternion rotationX = Quaternion.AngleAxis(vect, -Vector3.right);
        transform.rotation *= rotationX;
    }
}
