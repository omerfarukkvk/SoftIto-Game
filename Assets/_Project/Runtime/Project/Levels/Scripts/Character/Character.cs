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
    [Serializable]
    public class VehiclesChangeScores
    {
        public const int EmptyToHuman = 0;
        public const int HumanToHorse = 50;
        public const int HorseToBicycle = 100;
        public const int BicycleToOldCar = 150;
        public const int OldCarToChopper = 200;
        public const int ChopperToTank = 250;
        public const int TankToPlane = 300;
        public const int PlaneToPeugeout = 350;
    }

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

    public ParticleSystem partial;
    [SerializeField] private Vehicles CurrentVehicle;
    [SerializeField] private int Score;
    [SerializeField] private int Speed;
    private bool VehicleIsRenderable;
    private float MovementForce;
    public TextMeshProUGUI text;
    bool isTap = true;
    private bool isTriggered;


    void Awake()
    {
        GameModel.Instance.Score = 0;
        Time.timeScale = 1f;
    }

    private async void Update()
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

        // if (Input.GetKeyDown(KeyCode.Space))
        //     GameModel.Instance.Score += 10;
        if (transform.position.z > 120)
        {
            await ScreenModel.Instance.OpenScreen(ScreenKeys.WinScreen, ScreenLayers.Layer2);
            Time.timeScale = 0f;
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
            Time.timeScale = 0f;
            await ScreenModel.Instance.OpenScreen(ScreenKeys.GameOverScreen, ScreenLayers.Layer2);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
    }

    //değişecek if ile yapılacak!!!
    public void CheckScore()
    {
        switch (Score)
        {
            case int n when (n >= VehiclesChangeScores.EmptyToHuman && n < VehiclesChangeScores.HumanToHorse):
                if (!VehicleIsRenderable && CurrentVehicle != Vehicles.Human)
                {
                    GetVehiclePrefab(VehicleKeys.Human);
                    CurrentVehicle = Vehicles.Human;
                }

                break;
            case int n when (n >= VehiclesChangeScores.HorseToBicycle && n < VehiclesChangeScores.BicycleToOldCar):
                if (!VehicleIsRenderable && CurrentVehicle != Vehicles.Bicycle)
                {
                    // StartCoroutine(StartPartial());
                    StartCoroutine(StartPartial());
                    GetVehiclePrefab(VehicleKeys.Bicycle);
                    CurrentVehicle = Vehicles.Bicycle;
                }

                break;
            case VehiclesChangeScores.PlaneToPeugeout:
                if (!VehicleIsRenderable && CurrentVehicle != Vehicles.Peugeout308)
                {
                    StartCoroutine(StartPartial());
                    GetVehiclePrefab(VehicleKeys.Peugeout308);
                    CurrentVehicle = Vehicles.Peugeout308;
                }

                break;
        }
    }

    private IEnumerator StartPartial()
    {
        partial.Play();
        yield return new WaitForSeconds(0.5f);
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
        if (oldRendererObject != null)
        {
            Destroy(oldRendererObject);
        }
    }
}