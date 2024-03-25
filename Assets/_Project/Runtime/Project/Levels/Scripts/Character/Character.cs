using System;
using System.Collections;
using System.Collections.Generic;
using Codice.Client.BaseCommands.BranchExplorer;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Character : MonoBehaviour
{
    public enum Vehicles
    {
        Empty,
        Human,
        Horse,
        Bicycle,
        OldCar,
        Chopper,
        Tank,
        Plane,
        Peugeout308
    }

    [SerializeField] private Vehicles CurrentVehicle;
    [SerializeField] private int Score;
    [SerializeField] private int Speed;
    [SerializeField] private Slider slider;
    private bool VehicleIsRenderable;
    private float MovementForce;
    public TextMeshProUGUI text;
    bool isTap = true;


    void Awake()
    {
        GameModel.Instance.Score = 0;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        MovementForce = GameModel.Instance.MovementForce;
        Score = GameModel.Instance.Score;

        if (isTap)
        {
            if (Input.anyKey)
            {
                text.enabled = false;
                isTap = false;
            }
        }
        else
        {
            CheckScore();
            CheckVehicle();
            CharacterMovement();
        }
        // if (Input.GetKeyDown(KeyCode.Space))
        // {
        //     GameModel.Instance.Score += 10;
        // }
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
        switch (Score)
        {
            case 0:
                if (!VehicleIsRenderable && CurrentVehicle != Vehicles.Human)
                {
                    GetVehiclePrefab(VehicleKeys.Human);
                    CurrentVehicle = Vehicles.Human;
                }

                break;
            case 100:
                if (!VehicleIsRenderable && CurrentVehicle != Vehicles.Bicycle)
                {
                    GetVehiclePrefab(VehicleKeys.Bicycle);
                    CurrentVehicle = Vehicles.Bicycle;
                }

                break;
            case 200:
                if (!VehicleIsRenderable && CurrentVehicle != Vehicles.Peugeout308)
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
        VehicleIsRenderable = true;
        if (VehicleIsRenderable)
        {
            var bundle = await BundleModel.Instance.LoadPrefab(vehicleName, gameObject.transform);
            VehicleIsRenderable = false;
        }

        var oldRendererObject = GameObject.FindGameObjectWithTag("Vehicle");
        if (oldRendererObject != null && CurrentVehicle != Vehicles.Human)
        {
            Destroy(oldRendererObject);
        }
    }
}