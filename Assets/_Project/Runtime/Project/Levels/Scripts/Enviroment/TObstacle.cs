using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TObstacle : MonoBehaviour
{
    private float _speed = 40f;

    void Update()
    {
        transform.Rotate(Vector3.up, _speed * Time.deltaTime);
    }
}
