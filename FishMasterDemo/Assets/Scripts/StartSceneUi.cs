﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartSceneUi : MonoBehaviour
{

    public void NewGame()
    {
        // PlayerPrefs.DeleteAll();
        PlayerPrefs.DeleteKey("gold");
        PlayerPrefs.DeleteKey("lv");
        PlayerPrefs.DeleteKey("exp");
        PlayerPrefs.DeleteKey("scd");
        PlayerPrefs.DeleteKey("bcd");
        SceneManager.LoadScene(1);
    }


    public void OldGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitApp()
    {
        Application.Quit();
    }
}
