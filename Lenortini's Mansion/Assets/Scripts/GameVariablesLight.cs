using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameVariablesLight
{
    public static int maxIntensity = 4;
    public static bool isABatteryGrab = false;
    public static bool isResetTimeNeedeed = false;
    public static GameObject light = GameObject.Find("flashLight 1");
    public static Light spotlightChild = light.GetComponentInChildren<Light>();
}
