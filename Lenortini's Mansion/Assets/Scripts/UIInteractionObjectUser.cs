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
            batterie,
            batterie_pleine,
            porte_locked
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
            interactiveText.text = "(E) pour prendre";
        }else if(typeO == typeObjet.batterie_pleine){
            interactiveText.text = "La Batterie est pleine ! ";
        }else if(typeO == typeObjet.porte_locked)
        {
            interactiveText.text = "Cette porte est verrouilée ";
        }
        interactiveText.gameObject.SetActive(true);
    }
    public void HideInteractionText(){
        interactiveText.text = "";
        interactiveText.gameObject.SetActive(false);
    }

}
