using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManage : MonoBehaviour
{
    [SerializeField] public DialogManage uiManage;
    private PlayerMode playerMode;

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

    private int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        budget = GameObject.Find("TextBudget").GetComponent<Text>();
        budget.text = "Budget : กอ" + string.Format("{0:##,###}", budgetInteger).ToString();
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
            if(indicatorInteger > 0 && indicatorInteger <= 3)
            {
                --indicatorInteger;
                amountIndicator.rectTransform.position = amountText[indicatorInteger].rectTransform.position;
            }
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            if(indicatorInteger >= 0 && indicatorInteger < 3)
            {
                ++indicatorInteger;
                amountIndicator.rectTransform.position = amountText[indicatorInteger].rectTransform.position;
            }
        }

        int totalPrice = (100 * int.Parse(amountText[0].text)) +  (120 * int.Parse(amountText[1].text))
                       + (600 * int.Parse(amountText[2].text)) + (1200 * int.Parse(amountText[3].text));
        total.text = string.Format("{0:##,###}", totalPrice).ToString();
        if(totalPrice >= 100 && totalPrice <= budgetInteger)
        {
            confirmText.enabled = true;
            confirmImage.enabled = true;
            if(Input.GetKeyDown(KeyCode.F))
            {
                budget.text = "Budget : กอ" + string.Format("{0:##,###}", budgetInteger - totalPrice).ToString();
                uiManage.Interaction();
                Debug.Log("Good");
            }
        }
        else
        {
            confirmText.enabled = false;
            confirmImage.enabled = false;
        }
    }
}
