using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUIController : MonoBehaviour
{
    public Image[] healthBar;
    int currentValue;

    public static HealthUIController Instance;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        currentValue = 3;
    }

    void Update()
    {
        
    }

    public void UpdateHealthBar(int alpha)
    {
        if (alpha == -1 && currentValue > 0) healthBar[currentValue - 1].color = new Color(0.19f, 0.13f, 0.13f);
        if (alpha == 1 && currentValue <= 3) healthBar[currentValue + 1].color = new Color(1.0f, 1.0f, 1.0f);
        currentValue += alpha;
    }
}
