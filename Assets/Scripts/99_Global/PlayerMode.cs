using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMode : MonoBehaviour
{
    static public readonly int IDLE = 0;
    static public readonly int MOVING = 1;
    static public readonly int TALKING = 2;
    static public readonly int COOKING = 3;
    static public readonly int MANAGING = 4;
    static public readonly int CUTSCENE = 9;

    public int ControlState = -1;
}
