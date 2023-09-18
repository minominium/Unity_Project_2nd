using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerControl : MonoBehaviour
{
    //// DEFINES
    static private readonly Vector2 UP = new(0, 1);
    static private readonly Vector2 DOWN = new(0, -1);
    static private readonly Vector2 LEFT = new(-1, 0);
    static private readonly Vector2 RIGHT = new(1, 0);

    //// Public Variables
    public float moveSpeed = 4.0f;

    //// Private Variables
    // Basic Setting
    private PlayerMode playerMode;
    private Animator playerAnim;
    private Rigidbody2D playerRigid;

    private float timer = 0;
    
    // About Character Moving
    public Vector2 moveDir;
    private int counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        playerMode = GetComponent<PlayerMode>();
        playerAnim = GetComponent<Animator>();
        playerRigid = GetComponent<Rigidbody2D>();

        playerMode.ControlState = PlayerMode.IDLE;
        moveDir = DOWN;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer > 30)
        {
            timer = 0;
        }
        ++timer;
        PlayerInput();
    }

    private void FixedUpdate()
    {
        PlayerMove();
    }

    // Custom Function Below
    private void PlayerInput()
    {
        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) ||
            Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)))
        {
            if (playerMode.ControlState == PlayerMode.IDLE)
            {
                if (counter < 10)
                {
                    counter++;
                    if (Input.GetKeyDown(KeyCode.UpArrow)) { moveDir = UP; }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow)) { moveDir = LEFT; }
                    else if (Input.GetKeyDown(KeyCode.DownArrow)) { moveDir = DOWN; }
                    else if (Input.GetKeyDown(KeyCode.RightArrow)) { moveDir = RIGHT; }
                }
                else
                    playerMode.ControlState = PlayerMode.MOVING;
            }
            else if (playerMode.ControlState == PlayerMode.MOVING)
            {
                if (Input.GetKeyDown(KeyCode.UpArrow)) { moveDir = UP; }
                else if (Input.GetKeyDown(KeyCode.LeftArrow)) { moveDir = LEFT; }
                else if (Input.GetKeyDown(KeyCode.DownArrow)) { moveDir = DOWN; }
                else if (Input.GetKeyDown(KeyCode.RightArrow)) { moveDir = RIGHT; }
            }
        }

        if ( !(Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow) ||
               Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
             && (playerMode.ControlState != PlayerMode.TALKING) && (playerMode.ControlState != PlayerMode.COOKING) )
        {
            counter = 0;
            playerAnim.SetBool("isMoving", false);
            playerMode.ControlState = PlayerMode.IDLE;
        }

        if      (moveDir == UP)     { playerAnim.SetInteger("moveTo", 8); }
        else if (moveDir == DOWN)   { playerAnim.SetInteger("moveTo", 2); }
        else if (moveDir == LEFT)   { playerAnim.SetInteger("moveTo", 4); }
        else if (moveDir == RIGHT)  { playerAnim.SetInteger("moveTo", 6); }
    }

    private void PlayerMove()
    {
        if(playerMode.ControlState == PlayerMode.MOVING)
        {
            playerAnim.SetBool("isMoving", true);
            playerRigid.MovePosition(playerRigid.position + (moveSpeed * Time.fixedDeltaTime * moveDir));
        }
        else
            playerAnim.SetBool("isMoving", false);
    }
}
