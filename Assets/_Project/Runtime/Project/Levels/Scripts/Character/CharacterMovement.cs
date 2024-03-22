using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovement : MonoBehaviour
{
    public int Score;
    public int Speed;
    public float MovementForce;
    private GameObject GameScreen;

    private void Update()
    {
        MovementForce = GameModel.Instance.MovementForce;
        Score = GameModel.Instance.Score;

        if (MovementForce > 0 && transform.position.x < 3.5f)
        {
            transform.Translate(Vector3.right * MovementForce * Speed * Time.deltaTime);
        }
        else if (MovementForce < 0 && transform.position.x > -3.5f)
        {
            transform.Translate(Vector3.right * MovementForce * Speed * Time.deltaTime);
        }
        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }
}
