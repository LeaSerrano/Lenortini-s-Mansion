using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
{
    public static bool hasMovedCamera = false;
    public static bool hasMoved = false;
    public Image mouse;
    public GameObject keyboard; 
    private bool isTutorialOver = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if(isTutorialOver)
        {
            Destroy(gameObject);
            return;
        }
        if(hasMovedCamera)
        {
            Destroy(mouse);
            keyboard.SetActive(true);
        }
        if(hasMoved)
        {
            Destroy(keyboard);
            isTutorialOver = true;
            GameManager.isInTutorial = false;
        }
    }
}
