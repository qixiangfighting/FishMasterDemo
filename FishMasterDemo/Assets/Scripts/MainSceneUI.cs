using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MainSceneUI : MonoBehaviour
{
    public GameObject settingPanel;

    public void SwitchMute()
    {

        AudioManager.Instance.SwitchMuteState();

    }

    public void onBackButtonDown()
    {

        // 保存当前游戏

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
