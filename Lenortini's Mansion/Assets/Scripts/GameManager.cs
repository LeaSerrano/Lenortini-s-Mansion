using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int enemyNumber = 2;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public static void LoadVictory()
    {
        SceneManager.LoadScene("Victory");
    }

    public static void LoadDefeat()
    {
        SceneManager.LoadScene("Defeat");
    }

    public static void LoadGame()
    {
        SceneManager.LoadScene("World");
    }
}
