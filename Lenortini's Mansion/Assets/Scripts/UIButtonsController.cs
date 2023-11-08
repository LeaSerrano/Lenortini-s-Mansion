using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonsController : MonoBehaviour
{
    public void OnQuitClicked()
    {
        Application.Quit();
    }

    public void OnPlayClicked()
    {
        GameManager.LoadStory();
    }

    public void OnReviewClicked()
    {
        Application.OpenURL("https://docs.google.com/forms/d/e/1FAIpQLSeZLBjK39aGAxJiERbS3ehYGOF5bnSsjpWbc8Vbvau7C1bgtg/viewform?usp=pp_url&entry.1589827982=5&entry.1071592777=3&entry.1253266231=6&entry.774497967=5&entry.1138740158=2023-11-07&entry.371875895=Je+ne+souhaite+pas+le+pr%C3%A9ciser&entry.934767565=fefezfef");
    }

    public void OnSkipClicked()
    {
        GameManager.LoadGame();
    }

}
