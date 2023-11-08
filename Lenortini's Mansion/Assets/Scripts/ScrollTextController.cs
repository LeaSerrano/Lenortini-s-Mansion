using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTextController : MonoBehaviour
{

    void Start()
    {
        GetComponent<Animator>().Play("StoryScroll");
    }
    public void StartGame()
    {
        GameManager.LoadGame();
    }
}
