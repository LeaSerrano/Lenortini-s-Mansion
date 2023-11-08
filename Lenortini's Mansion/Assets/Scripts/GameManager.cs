using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static int enemyNumber = 3;
    public static bool isInTutorial = true;

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
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Victory");
    }

    public static void LoadDefeat()
    {
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("Defeat");
    }

    public static void LoadGame()
    {
        SceneManager.LoadScene("WorldV2");
    }

    public static void LoadStory()
    {
        SceneManager.LoadScene("Story");
    }
}
