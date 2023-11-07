using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatterySystem : MonoBehaviour
{

    public GameObject ui_battery_1;
    public GameObject ui_battery_2;
    public GameObject ui_battery_3;

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

        if (GameVariablesLight.maxIntensity == 3)
        {
            ui_battery_1.SetActive(true);
            ui_battery_2.SetActive(true);
            ui_battery_3.SetActive(true);
        }
        else if (GameVariablesLight.maxIntensity == 2)
        {
            ui_battery_1.SetActive(true);
            ui_battery_2.SetActive(true);
            ui_battery_3.SetActive(false);
        }
        else if (GameVariablesLight.maxIntensity == 1)
        {
            ui_battery_1.SetActive(true);
            ui_battery_2.SetActive(false);
            ui_battery_3.SetActive(false);
        }
        else if (GameVariablesLight.maxIntensity == 0)
        {
            ui_battery_1.SetActive(false);
            ui_battery_2.SetActive(false);
            ui_battery_3.SetActive(false);
        }

        GameVariablesLight.timeRemaining += Time.deltaTime;
        timeFlicker += Time.deltaTime;

        if (GameVariablesLight.timeRemaining > GameVariablesLight.timeRemaning3BatteryLevel && GameVariablesLight.timeRemaining < GameVariablesLight.timeRemaning3BatteryLevel + 0.5f && !timeDecrementBatteryLvl3)
        {
            GameVariablesLight.maxIntensity = 2;
            timeDecrementBatteryLvl3 = true;
        }
        else if (GameVariablesLight.timeRemaining > GameVariablesLight.timeRemaning2BatteryLevel && GameVariablesLight.timeRemaining < GameVariablesLight.timeRemaning2BatteryLevel + 0.5f && !timeDecrementBatteryLvl2)
        {
            GameVariablesLight.maxIntensity = 1;
            timeDecrementBatteryLvl2 = true;
        }
        else if (GameVariablesLight.timeRemaining > GameVariablesLight.timeRemaning1BatteryLevel && GameVariablesLight.timeRemaining < GameVariablesLight.timeRemaning1BatteryLevel + 0.5f && !timeDecrementBatteryLvl1)
        {
            GameVariablesLight.maxIntensity = 0;
            timeDecrementBatteryLvl1 = true;
        }

        if (GameVariablesLight.maxIntensity == 2 && !decrementedMaxIntensityBatteryLvl3)
        {
            GameVariablesLight.spotlightChild.intensity = 2;
            decrementedMaxIntensityBatteryLvl3 = true;
        }
        else if (GameVariablesLight.maxIntensity == 1 && !decrementedMaxIntensityBatteryLvl2)
        {
            GameVariablesLight.spotlightChild.intensity = 1;
            decrementedMaxIntensityBatteryLvl2 = true;
        }
        else if (GameVariablesLight.maxIntensity == 0 && !decrementedMaxIntensityBatteryLvl1)
        {
            GameVariablesLight.spotlightChild.intensity = 0;
            decrementedMaxIntensityBatteryLvl1 = true;
        }

        if (GameVariablesLight.isResetTimeNeedeed)
        {
            GameVariablesLight.isResetTimeNeedeed = false;
            GameVariablesLight.timeRemaining = 0.0f;
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

            if (flickerIntensity < GameVariablesLight.maxIntensity)
            {
                GameVariablesLight.spotlightChild.intensity = flickerIntensity;
            }
        }
    }

}
