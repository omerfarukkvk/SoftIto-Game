using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyHeadBomb : MonoBehaviour
{
    public bool IsMovable;
    private float _speed = 2f;

    void Update()
    {
        if(IsMovable)
            transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Wall"))
        {
            _speed = -_speed;
        }
    }
}
