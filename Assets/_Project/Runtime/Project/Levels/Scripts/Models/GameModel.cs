using System.Collections;
using System.Collections.Generic;
using _Project.Runtime.Core.Singleton;
using UnityEngine;

public class GameModel : SingletonModel<GameModel>
{
    public int Score;
    public float MovementForce;
    public bool ShowFPS;
    public bool MovementSliderVal = true;
}
