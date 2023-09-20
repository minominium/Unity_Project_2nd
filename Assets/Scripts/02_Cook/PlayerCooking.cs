using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCooking : MonoBehaviour
{
    //// Public variables
    public DialogManage uiManage;
    public GameObject panel;
    public Sprite sprite_Naporitan;
    public Sprite sprite_Sandwich;

    //// Private variables
    // Basic Setting
    private PlayerMode playerMode;
    private PlayerControl playerControl;
    private SpriteRenderer[] foodServing;
    private Dictionary<string, Sprite> foodServingDict = new();

    private GameObject stove;
    private SpriteRenderer[] stoveSprites;
    private Animator[] stoveAnimator;
    private GameObject cookIndicator;
    private Image[] cookIndicator_Image;

    private bool hasFood = false;
    private bool isCooking = false;
    private int cookState = 0;

    [SerializeField] private int missionCount = 0;

    private float timer = 0;
    private Image panelFade;

    // Start is called before the first frame update
    void Start()
    {
        playerMode = GetComponent<PlayerMode>();
        playerControl = GetComponent<PlayerControl>();
        foodServing = GetComponentsInChildren<SpriteRenderer>();

        panelFade = panel.GetComponent<Image>();

        stove = GameObject.Find("GasStove");
        stoveSprites = stove.GetComponentsInChildren<SpriteRenderer>();
        stoveAnimator = stove.GetComponentsInChildren<Animator>();

        cookIndicator = GameObject.Find("Slider");
        cookIndicator_Image = cookIndicator.GetComponentsInChildren<Image>();

        foodServingDict.Add("Naporitan", sprite_Naporitan);
        foodServingDict.Add("Sandwich", sprite_Sandwich);
    }

    // Update is called once per frame
    void Update()
    {
        Cooking();
        if (missionCount == 2)
        {
            playerMode.ControlState = PlayerMode.CUTSCENE;
            timer += Time.deltaTime;
            panelFade.color = new Color(0, 0, 0, timer);
            if (timer >= 1)
            {
                timer = 0;
                SceneIndex sceneChanger = GameObject.Find("SceneChanger").GetComponent<SceneIndex>();
                sceneChanger.toScene++;
                sceneChanger.loadingDone = true;
            }
        }
    }

    private void Cooking()
    {
        Debug.DrawRay(transform.position, playerControl.moveDir, Color.magenta);
        RaycastHit2D rayHit = Physics2D.Raycast(transform.position, playerControl.moveDir, 1, LayerMask.GetMask("Interaction"));

        if (rayHit.collider != null)
        {
            if (playerMode.ControlState == PlayerMode.IDLE || playerMode.ControlState == PlayerMode.MOVING)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    if (!hasFood)
                    {
                        if (rayHit.collider.CompareTag("Interact"))
                        {
                            uiManage.Interaction(rayHit.collider.gameObject);
                            playerMode.ControlState = PlayerMode.COOKING;
                        }
                    }
                    else
                    {
                        if (rayHit.collider.CompareTag("NPC"))
                        {
                            playerMode.ControlState = PlayerMode.TALKING;
                            uiManage.Interaction(rayHit.collider.gameObject);
                            foodServing[1].sprite = null;
                            foodServing[1].name = "Null";
                            hasFood = false;
                            cookState = 0;
                            for (int i = 0; i < 5; ++i)
                            { stoveSprites[i].enabled = true; }
                            missionCount++;
                        }
                    }
                }
            }
            else if (playerMode.ControlState == PlayerMode.TALKING)
            {
                if (Input.GetKeyDown(KeyCode.F))
                {
                    uiManage.Interaction(rayHit.collider.gameObject);
                    playerMode.ControlState = PlayerMode.IDLE;
                }
            }
            else if (playerMode.ControlState == PlayerMode.COOKING)
            {
                if (!isCooking && !hasFood)
                {
                    if (Input.GetKeyDown(KeyCode.Q))
                    {
                        ActivateIndicator(rayHit.collider.gameObject, "Naporitan");
                    }
                    else if (Input.GetKeyDown(KeyCode.E))
                    {
                        ActivateIndicator(rayHit.collider.gameObject, "Sandwich");
                    }
                }
                else if (isCooking)
                {
                    cookIndicator.GetComponent<Slider>().value = cookState;
                    if (cookState > 100)
                    {
                        isCooking = false;
                        stoveSprites[5].enabled = false;
                        foodServing[1].enabled = true;
                        playerMode.ControlState = PlayerMode.IDLE;
                        hasFood = true;
                        cookIndicator_Image[0].enabled = false;
                        cookIndicator_Image[1].enabled = false;
                        cookState = 0;
                    }
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        stoveAnimator[2].SetBool("isPressed", true);
                        cookState += 15;
                    }
                    else
                    {
                        stoveAnimator[2].SetBool("isPressed", false);
                        if (cookState > 0)
                        { cookState -= 1; }
                    }
                }
            }
        }
    }

    private void ActivateIndicator(GameObject obj, string str)
    {
        isCooking = true;
        uiManage.Interaction(obj);
        foodServing[1].sprite = foodServingDict[str];
        foodServing[1].name = str;
        foodServing[1].enabled = false;
        for (int i = 0; i < 5; ++i)
        { stoveSprites[i].enabled = false; }
        stoveSprites[5].enabled = true;
        cookIndicator_Image[0].enabled = true;
        cookIndicator_Image[1].enabled = true;
    }
}
