using Unity.VisualScripting;
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
    private bool toTheEnd = false;
    private float timer = 0.0f;

    private AudioSource audioSource;
    private bool audioCon = false;

    private void Start()
    {
        audioSource = GameObject.Find("SceneChanger").GetComponent<AudioSource>();

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
            audioSource.volume = 0.05f;
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
            if(!audioCon)
            {
                audioSource.pitch = 0.35f;
                audioCon = true;
            }

            if(!readyToEnd)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (dialogNum < 707)
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
                if(timer > 1 && !toTheEnd)
                {
                    audioSource.loop = false;
                    audioSource.mute = true;
                    dialogText.text = "Demo End";
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        toTheEnd = true;
                    }
                }
                else if(timer > 1 && toTheEnd)
                {
                    dialogText.text = " 플레이 해주셔서 감사합니다! \n 나가려면 F를 눌러주세요.";
                    if (Input.GetKeyDown(KeyCode.F))
                    {
#if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
#else
                        Application.Quit();
#endif
                    }
                }
                else
                {
                    timer += Time.deltaTime;
                    audioSource.volume = 0.05f * (1 - timer);
                    panelFade.color = new(0, 0, 0, timer);
                }
            }
        }
    }
}
