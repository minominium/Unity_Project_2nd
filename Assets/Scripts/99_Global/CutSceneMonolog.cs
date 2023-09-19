using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CutSceneMonolog : MonoBehaviour
{
    public GameObject dialogUI;
    public Text dialogText;
    private Image panelFade;

    private CutSceneDialog dialogComp;
    private int dialogNum;

    private bool readyToEnd = false;
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
                    SceneIndex sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneIndex>();
                    sceneChanger.toScene++;
                    sceneChanger.loadingDone = true;
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
                    SceneIndex sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneIndex>();
                    sceneChanger.toScene++;
                    sceneChanger.loadingDone = true;
                }
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                if (dialogNum < 505)
                {
                    dialogNum++;
                    dialogText.text = dialogComp.dialogDict[dialogNum];
                }
                else
                {
                    SceneIndex sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneIndex>();
                    sceneChanger.toScene++;
                    sceneChanger.loadingDone = true;
                }
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 7)
        {
            if(!readyToEnd)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (dialogNum < 705)
                    {
                        dialogNum++;
                        dialogText.text = dialogComp.dialogDict[dialogNum];
                    }
                    else
                    {
                        readyToEnd = true;
                    }
                }
            }
            else
            {
                if(timer > 1)
                {
                    dialogText.text = "Demo End";
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        dialogText.text = " Thanks for Playing! \n Press F to Quit.";
                        if(Input.GetKeyDown(KeyCode.F))
                        {
#if UNITY_EDITOR
                            UnityEditor.EditorApplication.isPlaying = false;
#else
                            Application.Quit();
#endif
                        }
                    }
                }
                else
                {
                    timer += Time.deltaTime;
                    panelFade.color = new(0, 0, 0, timer);
                }
            }
        }
    }
}
