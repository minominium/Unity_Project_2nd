using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInteract : MonoBehaviour
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

    private bool hasFood = false;
    [SerializeField] private int missionCount = 0;

    private AudioSource audioSource;
    private AudioStruct audioStruct;
    private int musicTrack = 0;

    private float timer = 0;
    private Image panelFade;

    // Start is called before the first frame update
    void Start()
    {
        playerMode = GetComponent<PlayerMode>();
        playerControl = GetComponent<PlayerControl>();
        foodServing = GetComponentsInChildren<SpriteRenderer>();

        panelFade = panel.GetComponent<Image>();

        foodServingDict.Add("Naporitan", sprite_Naporitan);
        foodServingDict.Add("Sandwich", sprite_Sandwich );
    }

    // Update is called once per frame
    void Update()
    {
        Interaction();
        if(missionCount == 2)
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

    private void Interaction()
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
                        if (rayHit.collider.CompareTag("Food"))
                        {
                            playerMode.ControlState = PlayerMode.TALKING;
                            uiManage.Interaction(rayHit.collider.gameObject);
                            foodServing[1].sprite = foodServingDict[rayHit.collider.name];
                            foodServing[1].name = rayHit.collider.name;
                            hasFood = true;
                        }
                        else if (rayHit.collider.CompareTag("Interact"))
                        {
                            playerMode.ControlState = PlayerMode.TALKING;
                            uiManage.Interaction(rayHit.collider.gameObject);
                            audioSource = GameObject.Find("SceneChanger").GetComponent<AudioSource>();
                            audioStruct = GameObject.Find("SceneChanger").GetComponent<AudioStruct>();
                            if (musicTrack == 0)
                            {
                                audioSource.clip = audioStruct.background1;
                                audioSource.Play();
                                musicTrack = 1;
                            }
                            else if(musicTrack == 1)
                            {
                                audioSource.clip = audioStruct.background2;
                                audioSource.Play();
                                musicTrack = 2;
                            }
                            else if(musicTrack == 2)
                            {
                                audioSource.clip = null;
                                musicTrack = 0;
                            }
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
        }
    }
}
