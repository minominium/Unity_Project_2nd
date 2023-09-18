using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStart : MonoBehaviour
{
    public GameObject panel;

    private bool clicked = false;
    private float timer = 0;
    private Image panelFade;

    private void Start()
    {
        panelFade = panel.GetComponent<Image>();
    }

    private void Update()
    {
        if(clicked)
        {
            timer += Time.deltaTime;
            panelFade.color = new Color(0, 0, 0, timer);
            if (timer >= 1)
            {
                timer = 0;
                SceneManager.LoadScene("98_Loading");
            }
        }
    }

    public void ToLoadingScene()
    {
        if(!clicked)
        {
            clicked = true;
        }
    }
}
