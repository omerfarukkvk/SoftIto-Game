using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character : MonoBehaviour
{
    public enum Vehicles
    {
        Human,
        Horse,
        Bicycle,
        NinetiesCar,
        Chopper,
        Tank,
        Peugeout308
    }

    private Vehicles CurrentVehicle;
    private int Score;
    [SerializeField] private int Speed;
    private bool VehicleIsRenderable;
    private float MovementForce;
    private GameObject GameScreen;

    void Awake()
    {
        CurrentVehicle = Vehicles.Human;
    }

    private void Update()
    {
        MovementForce = GameModel.Instance.MovementForce;
        Score = GameModel.Instance.Score;
        CheckVehicle();
        CharacterMovement();
        CheckScore();

        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameModel.Instance.Score += 10;
        }
    }

    private void CharacterMovement()
    {

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

    public void CheckScore()
    {
        switch(Score)
        {
            case 10:
                if (VehicleIsRenderable == false)
                {
                    GetVehiclePrefab(VehicleKeys.Bicycle);
                    CurrentVehicle = Vehicles.Bicycle;
                }
                break;
            case 100:
                if (VehicleIsRenderable == false)
                {
                    GetVehiclePrefab(VehicleKeys.Peugeout308);
                    CurrentVehicle = Vehicles.Peugeout308;
                }
                break;
        }
    }

    private void CheckVehicle()
    {
        switch (CurrentVehicle)
        {
            case Vehicles.Human:
                Speed = 5;
                break;
            case Vehicles.Horse:
                Speed = 6;
                break;
            case Vehicles.Bicycle:
                Speed = 7;
                break;
            case Vehicles.Peugeout308:
                Speed = 10;
                break;
        }
    }

    private async void GetVehiclePrefab(string vehicleName)
    {
        var oldRendererObject = GameObject.FindGameObjectWithTag("Vehicle");
        Destroy(oldRendererObject);
        VehicleIsRenderable = true;
        if (VehicleIsRenderable)
        {
            var bundle = await BundleModel.Instance.LoadPrefab(vehicleName, gameObject.transform);
            VehicleIsRenderable = false;
        }
    }
}
