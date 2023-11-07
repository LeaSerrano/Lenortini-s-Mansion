using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIInteractionObjectUser : MonoBehaviour
{   
    TMP_Text interactiveText;
    public enum typeObjet{
            porte,
            batterie
        }
    public float distance = 2f; 
    
    void Start()
    {
        interactiveText = GameObject.Find("interactiveText").GetComponent<TMPro.TMP_Text>();
        interactiveText.gameObject.SetActive(true);
    }


    public void ShowInteractionText(typeObjet typeO){
        if (typeO == typeObjet.porte){
            interactiveText.text = "(R) pour ouvrir";
        }else if (typeO == typeObjet.batterie){
            interactiveText.text = "(E) pour récupérer";
        }
        interactiveText.gameObject.SetActive(true);
    }
    public void HideInteractionText(){
        interactiveText.text = "";
        interactiveText.gameObject.SetActive(false);
    }

}
