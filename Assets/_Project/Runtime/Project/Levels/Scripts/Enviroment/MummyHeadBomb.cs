using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MummyHeadBomb : MonoBehaviour
{
    private float _speed = 2f;

    void Update()
    {
        transform.Translate(Vector3.right * _speed * Time.deltaTime);
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("girdi");
        if(other.CompareTag("Wall"))
        {
            transform.Rotate(Vector3.up * 180);
        }
    }
}
