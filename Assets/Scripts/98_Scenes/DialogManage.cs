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
                dialogText.text = obj.name + "을(를) 받았다. \n";
            }
            else if(obj.CompareTag("NPC"))
            {
                int randomValue = Random.Range(1, 5);
                if      (randomValue == 1) { dialogText.text = " 고마워 \n"; }
                else if (randomValue == 2) { dialogText.text = " 배고파 죽을뻔 했네. \n"; }
                else if (randomValue == 3) { dialogText.text = " 으음~ \n"; }
                else if (randomValue == 4) { dialogText.text = " 이리 내놔! \n"; }
            }
            else if(obj.CompareTag("Interact"))
            {
                if(obj.name == "MusicBox")
                {
                    dialogText.text = " 이건 " + obj.name + "이다.";
                }
                else if(obj.name == "GasStove")
                {
                    dialogText.text = " 요리할 음식을 고르자 : \n Q - 나폴리탄 스파게티 / E - 살라미 샌드위치 ";
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
            dialogText.text = "주문 성공! \n";
        }
        else
        {
            isUIActive = false;
            dialogUI.SetActive(false);
            dialogText.text = "";
        }
    }
}
