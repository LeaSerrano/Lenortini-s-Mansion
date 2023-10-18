using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class BatterySystem : MonoBehaviour
{
    public float timeRemaning3BatteryLevel;
    public float timeRemaning2BatteryLevel;
    public float timeRemaning1BatteryLevel;

    private float timeRemaining = 0.0f;
    private float timeFlicker = 0.0f;
    private float flickerInterval = 0.1f;
    private float flickerIntensity = 0f;

    private bool timeDecrementBatteryLvl3 = false;
    private bool timeDecrementBatteryLvl2 = false;
    private bool timeDecrementBatteryLvl1 = false;

    private bool decrementedMaxIntensityBatteryLvl3 = false;
    private bool decrementedMaxIntensityBatteryLvl2 = false;
    private bool decrementedMaxIntensityBatteryLvl1 = false;


    void Update()
    {
        timeRemaining += Time.deltaTime;
        timeFlicker += Time.deltaTime;

        if (timeRemaining > timeRemaning3BatteryLevel && timeRemaining < timeRemaning3BatteryLevel + 0.5f && !timeDecrementBatteryLvl3)
        {
            GameVariablesLight.maxIntensity = 3;
            timeDecrementBatteryLvl3 = true;
        }
        else if (timeRemaining > timeRemaning2BatteryLevel && timeRemaining < timeRemaning2BatteryLevel + 0.5f && !timeDecrementBatteryLvl2)
        {
            GameVariablesLight.maxIntensity = 2;
            timeDecrementBatteryLvl2 = true;
        }
        else if (timeRemaining > timeRemaning1BatteryLevel && timeRemaining < timeRemaning1BatteryLevel + 0.5f && !timeDecrementBatteryLvl1)
        {
            GameVariablesLight.maxIntensity = 1;
            timeDecrementBatteryLvl1 = true;
        }

        if (GameVariablesLight.maxIntensity == 3 && !decrementedMaxIntensityBatteryLvl3)
        {
            GameVariablesLight.spotlightChild.intensity = 2;
            decrementedMaxIntensityBatteryLvl3 = true;
        }
        else if (GameVariablesLight.maxIntensity == 2 && !decrementedMaxIntensityBatteryLvl2)
        {
            GameVariablesLight.spotlightChild.intensity = 1;
            decrementedMaxIntensityBatteryLvl2 = true;
        }
        else if (GameVariablesLight.maxIntensity == 1 && !decrementedMaxIntensityBatteryLvl1)
        {
            GameVariablesLight.spotlightChild.intensity = 0;
            decrementedMaxIntensityBatteryLvl1 = true;
        }

        if (GameVariablesLight.isResetTimeNeedeed)
        {
            GameVariablesLight.isResetTimeNeedeed = false;
            timeRemaining = 0.0f;
            timeDecrementBatteryLvl3 = false;
            timeDecrementBatteryLvl2 = false;
            timeDecrementBatteryLvl1 = false;
            decrementedMaxIntensityBatteryLvl3 = false;
            decrementedMaxIntensityBatteryLvl2 = false;
            decrementedMaxIntensityBatteryLvl1 = false;
        }

        if (timeFlicker >= flickerInterval)
        {
            timeFlicker = 0;
            FlickerIntensity();
        }
    }

    void FlickerIntensity()
    {
        if (GameVariablesLight.spotlightChild.intensity > 0)
        {
            float randomFactor = Random.Range(0.9f, 1.1f);

            flickerIntensity = GameVariablesLight.spotlightChild.intensity * randomFactor;

            GameVariablesLight.spotlightChild.intensity = flickerIntensity;
        }
    }
}
