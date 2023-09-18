using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogManage : MonoBehaviour
{
    public GameObject dialogUI;
    public Text dialogText;
    
    public bool isUIActive = false;

    public void Interaction(GameObject obj)
    {
        if(!isUIActive) 
        {
            isUIActive = true;
            dialogUI.SetActive(true);
            if (obj.CompareTag("Food"))
            {
                dialogText.text = " Got " + obj.name + ". \n";
            }
            else if(obj.CompareTag("NPC"))
            {
                int randomValue = Random.Range(1, 5);
                if      (randomValue == 1) { dialogText.text = " Thank You! \n"; }
                else if (randomValue == 2) { dialogText.text = " My god I'm starving. \n"; }
                else if (randomValue == 3) { dialogText.text = " Hmmmm~ \n"; }
                else if (randomValue == 4) { dialogText.text = " Give it to me! \n"; }
            }
            else if(obj.CompareTag("Interact"))
            {
                if(obj.name == "MusicBox")
                {
                    dialogText.text = " This is " + obj.name + ".";
                }
                else if(obj.name == "GasStove")
                {
                    dialogText.text = " Q or E to choice : \n Q - Naporitan / E - Sandwich ";
                }
            }
        }
        else
        {
            isUIActive = false;
            dialogUI.SetActive(false);
            dialogText.text = "";
        }
    }

    public void Interaction()
    {
        if (!isUIActive)
        {
            isUIActive = true;
            dialogUI.SetActive(true);
            dialogText.text = "Successfully Ordered! \n";
        }
        else
        {
            isUIActive = false;
            dialogUI.SetActive(false);
            dialogText.text = "";
        }
    }
}
