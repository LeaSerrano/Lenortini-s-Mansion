using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int currentHealth;
    [SerializeField]
    private int maxHealth;
    public Material blurMaterial;

    public static PlayerHealth Instance;

    void Awake()
    {
        Instance = this;
    }

    public void Heal(int healValue)
    {
        currentHealth += healValue;
        if (currentHealth > maxHealth) currentHealth = maxHealth;
        HealthUIController.Instance.UpdateHealthBar(healValue);
    }

    public void Hurt(int damageValue)
    {
        currentHealth -= damageValue;
        HealthUIController.Instance.UpdateHealthBar(-1 * damageValue);
        CheckHealth();
    }

    private void CheckHealth()
    {
        if (currentHealth <= 0)
        {
            GameManager.LoadDefeat();
        }
        // defaite (TO DO)
    }

    private IEnumerator BlurEffect()
    {
        yield return new WaitForSeconds(2.0f);
    }

    public int GetCurrentHealth() { return currentHealth; }
    public int GetMaxHealth() { return maxHealth; }
}
