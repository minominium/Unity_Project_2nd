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
                dialogText.text = obj.name + "��(��) �޾Ҵ�. \n";
            }
            else if(obj.CompareTag("NPC"))
            {
                int randomValue = Random.Range(1, 5);
                if      (randomValue == 1) { dialogText.text = " ���� \n"; }
                else if (randomValue == 2) { dialogText.text = " ����� ������ �߳�. \n"; }
                else if (randomValue == 3) { dialogText.text = " ����~ \n"; }
                else if (randomValue == 4) { dialogText.text = " �̸� ����! \n"; }
            }
            else if(obj.CompareTag("Interact"))
            {
                if(obj.name == "MusicBox")
                {
                    dialogText.text = " �̰� " + obj.name + "�̴�.";
                }
                else if(obj.name == "GasStove")
                {
                    dialogText.text = " �丮�� ������ ���� : \n Q - ������ź ���İ�Ƽ / E - ���� ������ġ ";
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
            dialogText.text = "�ֹ� ����! \n";
        }
        else
        {
            isUIActive = false;
            dialogUI.SetActive(false);
            dialogText.text = "";
        }
    }
}
