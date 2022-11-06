using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public int moveDistance = -18;
    public float speed = 10;

    public void MoveCamera()
    {
        transform.position = new Vector3(transform.position.x + moveDistance, 0, -10);
    }
}
