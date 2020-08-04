using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject[] gunGos;

    // 使用的是第几挡炮弹
    private int costIndex = 0;
    // 没炮所需的金币数 和 造成的伤害值
    private int[] oneShootCosts =
        {5, 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 200, 300, 400, 500, 600, 700, 800, 900, 1000};

    public void OnButtonPDown()
    {
        gunGos[costIndex/4].SetActive(false);
        costIndex++;
        costIndex = (costIndex > oneShootCosts.Length - 1) ? 0 : costIndex;
        gunGos[costIndex/4].SetActive(true);
    }

    public void OnButtonMDown()
    {
        gunGos[costIndex/4].SetActive(false);
        costIndex--;
        costIndex = (costIndex < 0 ) ? oneShootCosts.Length - 1 : costIndex;
        gunGos[costIndex/4].SetActive(true);
    }
}