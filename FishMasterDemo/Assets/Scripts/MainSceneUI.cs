using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSceneUI : MonoBehaviour
{
    public GameObject settingPanel;
    public Toggle muteToggle;


    private void Start()
    {
        muteToggle.isOn = !AudioManager.Instance.IsMure;
    }

    public void SwitchMute(bool isOn)
    {

        AudioManager.Instance.SwitchMuteState(isOn);

    }

    public void onBackButtonDown()
    {

        // 保存当前游戏
        PlayerPrefs.SetInt("gold", GameController.Instance.gold);
        PlayerPrefs.SetInt("LV", GameController.Instance.lv);
        PlayerPrefs.SetFloat("scd", GameController.Instance.smallTimer);
        PlayerPrefs.SetFloat("bcd", GameController.Instance.bigTimer);
        PlayerPrefs.SetInt("exp", GameController.Instance.exp);

        int temp = AudioManager.Instance.IsMure == false ? 0 : 1;
        PlayerPrefs.SetInt("mute", temp);

        UnityEngine.SceneManagement.SceneManager.LoadScene(0);

    }


    public void onSettingButtonDown()
    {

        settingPanel.SetActive(true);

    }

    public void onCloseButtonDown()
    {

        settingPanel.SetActive(false);
    }
}
