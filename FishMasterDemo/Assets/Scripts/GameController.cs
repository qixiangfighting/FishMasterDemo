using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] gunGos;

    public int lv = 0;
    public Text oneShootCostText;

    public GameObject[] bullet1Gos;
    public GameObject[] bullet2Gos;
    public GameObject[] bullet3Gos;
    public GameObject[] bullet4Gos;

    public GameObject[] bullet5Gos;

    // 使用的是第几挡炮弹
    private int costIndex = 0;

    // 没炮所需的金币数 和 造成的伤害值
    private int[] oneShootCosts =
        {5, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000};


    private void Update()
    {
        ChangeBulletCost();
    }

    public void OnButtonPDown()
    {
        gunGos[costIndex / 4].SetActive(false);
        costIndex++;
        costIndex = (costIndex > oneShootCosts.Length - 1) ? 0 : costIndex;
        gunGos[costIndex / 4].SetActive(true);
        oneShootCostText.text = "$" + oneShootCosts[costIndex];
    }

    public void OnButtonMDown()
    {
        gunGos[costIndex / 4].SetActive(false);
        costIndex--;
        costIndex = (costIndex < 0) ? oneShootCosts.Length - 1 : costIndex;
        gunGos[costIndex / 4].SetActive(true);
        oneShootCostText.text = "$" + oneShootCosts[costIndex];
    }

    void ChangeBulletCost()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            OnButtonMDown();
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {
            OnButtonPDown();
        }
    }

    void Fire()
    {
        // 那组子弹
        GameObject[] useBullets;
        //组里面哪一个子弹
        int bulletIndex;
        if (Input.GetMouseButtonDown(0))
        {
            switch (costIndex / 4)
            {
                case 0:
                    useBullets = bullet1Gos;
                    break;
                case 1:
                    useBullets = bullet2Gos;
                    break;
                case 2:
                    useBullets = bullet3Gos;
                    break;
                case 3:
                    useBullets = bullet4Gos;
                    break;
                case 4:
                    useBullets = bullet5Gos;
                    break;
            }

            bulletIndex = (lv % 10 >= 9) ? 9 : lv % 10;
            
        }
    }
}