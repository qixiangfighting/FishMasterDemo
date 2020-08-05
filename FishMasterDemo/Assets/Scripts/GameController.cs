using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public GameObject[] gunGos;

    public Text goldText;
    public Text lvText;
    public Text lvNameText;
    public Text smallCountdownText;
    public Text bigCountdownText;
    public Button bigCountdownButton;
    public Button backButton;
    public Button settingButton;
    public Slider expSlider;

    public int lv = 0;
    public int exp = 0;
    public int gold = 500;
    public const int bigCountdown = 240;
    public const int smallCountdown = 60;
    public float bigTimer = bigCountdown;
    public float smallTimer = smallCountdown;


    public Text oneShootCostText;

    public Transform bulletHolder;
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


    private string[] lvName = {"新手", "入门", "钢铁", "青铜", " 白银", "黄金", "白金", "钻石", "大师", "宗师"};

    private void Start()
    {
        bigTimer = bigCountdown;
        smallTimer = smallCountdown;
    }

    void UpdateUI()
    {

        var dd = Time.deltaTime;
        bigTimer = bigTimer - dd ;
        smallTimer  = smallTimer - Time.deltaTime;

        if (smallTimer <=0)
        {
            smallTimer = smallCountdown;
            gold += 50;
        }

        if (bigTimer <=0 && bigCountdownButton.gameObject.activeSelf == false)
        {
            bigCountdownText.gameObject.SetActive(false);
            bigCountdownButton.gameObject.SetActive(true);
        }


        // 经验等级计算方式：升级所需经验 = 1000+200*当前等级

        while (exp >= 1000 + 200 * lv)
        {
            lv++;
            exp = exp - (1000 + 200 * lv);
        }

        goldText.text = "$" + gold;
        lvText.text = lv.ToString();

        if ((lv / 10) <= 9)
        {
            lvNameText.text = lvName[lv / 10];
        }
        else
        {
            lvNameText.text = lvName[9];
        }

        smallCountdownText.text = "  " + (int) smallTimer / 10 + "  " + (int)smallTimer % 10;
        bigCountdownText.text = (int)bigTimer + "s";
        expSlider.value = ((float)exp)/(1000+200*lv);
    }

    private void Update()
    {
        ChangeBulletCost();
        Fire();
        UpdateUI();
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
        GameObject[] useBullets = bullet5Gos;
        //组里面哪一个子弹
        int bulletIndex;
        if (Input.GetMouseButtonDown(0) && EventSystem.current.IsPointerOverGameObject() == false)
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

            GameObject bullet = Instantiate(useBullets[bulletIndex]);
            bullet.transform.SetParent(bulletHolder, false);
            bullet.transform.position = gunGos[costIndex / 4].transform.Find("FirePos").transform.position;
            bullet.transform.rotation = gunGos[costIndex / 4].transform.Find("FirePos").transform.rotation;

            bullet.GetComponent<BulletAttr>().damage = oneShootCosts[costIndex];
            bullet.AddComponent<Ef_AutoMove>().Dir = Vector3.up;
            bullet.GetComponent<Ef_AutoMove>().speed = bullet.GetComponent<BulletAttr>().speed;
        }
    }
}