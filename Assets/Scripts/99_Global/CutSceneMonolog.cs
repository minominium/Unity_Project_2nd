using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CutSceneMonolog : MonoBehaviour
{
    public GameObject dialogUI;
    public Text dialogText;
    private Image panelFade;

    private CutSceneDialog dialogComp;
    private int dialogNum;

    private float timer = 0.0f;

    private void Start()
    {
        dialogNum = SceneManager.GetActiveScene().buildIndex * 100 + 1;
        dialogComp = GetComponent<CutSceneDialog>();
        panelFade = GameObject.Find("TitleFade").GetComponent<Image>();

        dialogUI.SetActive(true);
        dialogText.text = dialogComp.dialogDict[dialogNum];
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (dialogNum < 105)
                {
                    dialogNum++;
                    dialogText.text = dialogComp.dialogDict[dialogNum];
                }
                else
                {
                    timer = 0;
                    SceneIndex sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneIndex>();
                    sceneChanger.toScene++;
                    sceneChanger.loadingDone = true;
                    Debug.Log(timer);
                }
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (dialogNum < 305)
                {
                    dialogNum++;
                    dialogText.text = dialogComp.dialogDict[dialogNum];
                }
                else
                {
                    timer = 0;
                    SceneIndex sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneIndex>();
                    sceneChanger.toScene++;
                    sceneChanger.loadingDone = true;
                    Debug.Log(timer);
                }
            }
        }
    }
}
