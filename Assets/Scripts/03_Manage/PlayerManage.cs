using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManage : MonoBehaviour
{
    [SerializeField] public DialogManage uiManage;
    public GameObject panel;

    private PlayerMode playerMode;
    private SceneIndex sceneChanger;

    private Text budget;
    private Text total;
    private GameObject amountObj;
    private Image amountIndicator;
    private Text[] amountText;
    private GameObject confirmObj;
    private Text confirmText;
    private Image confirmImage;

    private int budgetInteger = 10000;
    private int indicatorInteger = 0;

    [SerializeField] private int missionCount = 0;

    private float timer = 0;
    private Image panelFade;

    // Start is called before the first frame update
    void Start()
    {
        panelFade = panel.GetComponent<Image>();

        playerMode = GameObject.Find("PlayerServe").GetComponent<PlayerMode>();
        sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneIndex>();

        budget = GameObject.Find("TextBudget").GetComponent<Text>();
        budget.text = "���� : \n ��" + string.Format("{0:##,###}", budgetInteger).ToString();
        total = GameObject.Find("TextTotal").GetComponent<Text>();
        amountObj = GameObject.Find("Amounts");
        amountIndicator = amountObj.GetComponentInChildren<Image>();
        amountText = amountObj.GetComponentsInChildren<Text>();

        confirmObj = GameObject.Find("Confirm");
        confirmText = confirmObj.GetComponentInChildren<Text>();
        confirmImage = confirmObj.GetComponentInChildren<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        int amountTmp = int.Parse(amountText[indicatorInteger].text);

        if(missionCount == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (amountTmp > 0 && amountTmp <= 99)
                {
                    --amountTmp;
                    amountText[indicatorInteger].text = amountTmp.ToString();
                }
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (amountTmp >= 0 && amountTmp < 99)
                {
                    ++amountTmp;
                    amountText[indicatorInteger].text = amountTmp.ToString();
                }
            }

            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (indicatorInteger > 0 && indicatorInteger <= 3)
                {
                    --indicatorInteger;
                    amountIndicator.rectTransform.position = amountText[indicatorInteger].rectTransform.position;
                }
            }
            else if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (indicatorInteger >= 0 && indicatorInteger < 3)
                {
                    ++indicatorInteger;
                    amountIndicator.rectTransform.position = amountText[indicatorInteger].rectTransform.position;
                }
            }
        }

        int totalPrice = (100 * int.Parse(amountText[0].text)) +  (120 * int.Parse(amountText[1].text))
                       + (600 * int.Parse(amountText[2].text)) + (1200 * int.Parse(amountText[3].text));
        total.text = string.Format("{0:##,###}", totalPrice).ToString();
        if(totalPrice >= 100 && totalPrice <= budgetInteger)
        {
            confirmText.enabled = true;
            confirmImage.enabled = true;
            
            if (missionCount == 1)
            {
                playerMode.ControlState = PlayerMode.CUTSCENE;
                timer += Time.deltaTime;
                panelFade.color = new Color(0, 0, 0, timer);
                if (timer >= 1)
                {
                    timer = 0;
                    sceneChanger.toScene++;
                    sceneChanger.loadingDone = true;
                }
            }
            else
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (budgetInteger - totalPrice == 0)
                    {
                        sceneChanger.budgetZero = true;
                    }
                    budget.text = "���� : \n ��" + string.Format("{0:##,###}", budgetInteger - totalPrice).ToString();
                    uiManage.Interaction();
                    missionCount = 1;
                }
            }
        }
        else
        {
            confirmText.enabled = false;
            confirmImage.enabled = false;
        }
    }
}
