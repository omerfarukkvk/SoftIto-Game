using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using FMODUnity;

public class Character : MonoBehaviour
{
    [Serializable]
    public class VehiclesChangeScores
    {
        public const int EmptyToHuman = 0;
        public const int HumanToHorse = 50;
        public const int HorseToBicycle = 100;
        public const int BicycleToVintageCar = 150;
        public const int VintageCarToChopper = 200;
        public const int ChopperToSportCar = 250;
        public const int SportCarToPlane = 300;
        public const int PlaneToPeugeout = 350;
    }

    public enum Vehicles
    {
        Empty,
        Human,
        Horse,
        Bicycle,
        VintageCar,
        Chopper,
        SportCar,
        Plane,
        Peugeout308
    }

    public ParticleSystem partial;
    [SerializeField] private Vehicles CurrentVehicle;
    [SerializeField] private int Score;
    [SerializeField] private int Speed;
    private bool VehicleIsRenderable;
    private float MovementForce;
    public TextMeshProUGUI text;
    bool isTap = true;
    private bool isTriggered;

    //FMOD
    public EventReference CrashSound;

    void Awake()
    {
        GameModel.Instance.Score = 0;
        Time.timeScale = 1f;
    }

    private void Update()
    {
        MovementForce = GameModel.Instance.MovementForce;
        Score = GameModel.Instance.Score;

        if (Score < 0)
        {
            GameModel.Instance.Score = 0;
        }

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
    }

    private void CharacterMovement()
    {
        if (MovementForce > 0)
        {
            transform.Translate(Vector3.right * MovementForce * Speed * Time.deltaTime);
        }
        else if (MovementForce < 0)
        {
            transform.Translate(Vector3.left * -MovementForce * Speed * Time.deltaTime);
        }

        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
    }

    private async void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Area") && !isTriggered)
        {
            var pointLabel = other.GetComponentInChildren<Canvas>().GetComponentInChildren<TMP_Text>();
            GameModel.Instance.Score += int.Parse(pointLabel.text);
            CheckScore();
            isTriggered = true;
        }

        if (other.CompareTag("Wall"))
        {
            RuntimeManager.PlayOneShot(CrashSound);
            Time.timeScale = 0f;
            await ScreenManager.Instance.OpenScreen(ScreenKeys.GameOverScreen, ScreenLayers.Layer2);
        }
        if(other.CompareTag("Finish"))
        {
            Time.timeScale = 0f;
            await ScreenManager.Instance.OpenScreen("WinnerScreen", ScreenLayers.Layer1);
        }
        if(other.CompareTag("Diamond"))
        {
            GameModel.Instance.DiamondVal += 1;
            Destroy(other.gameObject);
        }
        if(other.CompareTag("Bomb"))
        {
            GameModel.Instance.Score -= 10;
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
    }

    public void CheckScore()
    {
        switch (Score)
        {
            //Human
            case int n when (n >= VehiclesChangeScores.EmptyToHuman && n < VehiclesChangeScores.HumanToHorse):
                if (!VehicleIsRenderable && CurrentVehicle != Vehicles.Human)
                {
                    GetVehiclePrefab(VehicleKeys.Human);
                    CurrentVehicle = Vehicles.Human;
                }

                break;
            //Horse
            case int n when (n >= VehiclesChangeScores.HumanToHorse && n < VehiclesChangeScores.HorseToBicycle):
                if (!VehicleIsRenderable && CurrentVehicle != Vehicles.Horse)
                {
                    GetVehiclePrefab(VehicleKeys.Horse);
                    CurrentVehicle = Vehicles.Horse;
                }

                break;
            //Bicycle
            case int n when (n >= VehiclesChangeScores.HorseToBicycle && n < VehiclesChangeScores.BicycleToVintageCar):
                if (!VehicleIsRenderable && CurrentVehicle != Vehicles.Bicycle)
                {
                    GetVehiclePrefab(VehicleKeys.Bicycle);
                    CurrentVehicle = Vehicles.Bicycle;
                }

                break;
            //VintageCar
            case int n when (n >= VehiclesChangeScores.BicycleToVintageCar && n < VehiclesChangeScores.VintageCarToChopper):
                if (!VehicleIsRenderable && CurrentVehicle != Vehicles.VintageCar)
                {
                    GetVehiclePrefab(VehicleKeys.VintageCar);
                    CurrentVehicle = Vehicles.VintageCar;
                }

                break;
            //Chopper
            case int n when (n >= VehiclesChangeScores.VintageCarToChopper && n < VehiclesChangeScores.ChopperToSportCar):
                if (!VehicleIsRenderable && CurrentVehicle != Vehicles.Chopper)
                {
                    GetVehiclePrefab(VehicleKeys.Chopper);
                    CurrentVehicle = Vehicles.Chopper;
                }

                break;
            //SportCar
            case int n when (n >= VehiclesChangeScores.ChopperToSportCar && n < VehiclesChangeScores.SportCarToPlane):
                if (!VehicleIsRenderable && CurrentVehicle != Vehicles.SportCar)
                {
                    GetVehiclePrefab(VehicleKeys.SportCar);
                    CurrentVehicle = Vehicles.SportCar;
                }

                break;
            //Plane
            case int n when (n >= VehiclesChangeScores.SportCarToPlane && n < VehiclesChangeScores.PlaneToPeugeout):
                if (!VehicleIsRenderable && CurrentVehicle != Vehicles.Plane)
                {
                    GetVehiclePrefab(VehicleKeys.Plane);
                    CurrentVehicle = Vehicles.Plane;
                }

                break;
            //Peugeout
            case VehiclesChangeScores.PlaneToPeugeout:
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
                Speed = 3;
                break;
            case Vehicles.Horse:
                Speed = 3;
                break;
            case Vehicles.Bicycle:
                Speed = 4;
                break;
            case Vehicles.VintageCar:
                Speed = 5;
                break;
            case Vehicles.Chopper:
                Speed = 6;
                break;
            case Vehicles.SportCar:
                Speed = 7;
                break;
            case Vehicles.Plane:
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
            partial.Play();
            var bundle = await BundleModel.Instance.LoadPrefab(vehicleName, gameObject.transform);
            VehicleIsRenderable = false;
        }

        var oldRendererObject = GameObject.FindGameObjectWithTag("Vehicle");
        if (oldRendererObject != null)
        {
            Destroy(oldRendererObject);
        }
    }
}