using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneIndex : MonoBehaviour
{
    public int nowScene = -1;
    public int toScene = 0;
    public bool loadingDone = false;

    public bool budgetZero = false;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        DontDestroyOnLoad(gameObject);
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Update()
    {
        if (loadingDone)
        {
            loadingDone = false;
            SceneManager.LoadScene(toScene);
        }
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode loadSceneMode)
    {
        nowScene = scene.buildIndex;
        if(nowScene == 8)
        {
            toScene++;
            loadingDone = true;
        }
    }
}
