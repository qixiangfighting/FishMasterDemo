﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMaker : MonoBehaviour
{
    public Transform fishHolder;
    public Transform[] genPositions;
    public GameObject[] fishPrefabs;

    public float waveGenWaitTime = 0.3f;

    public float fishGenWaitTime = 0.5f;
    void Start()
    {
        InvokeRepeating("MakeFishes",0,waveGenWaitTime);
    }

    void MakeFishes()
    {
        int genPosIndex = Random.Range(0, genPositions.Length);
        int fishPreIndex = Random.Range(0, fishPrefabs.Length);

        int maxNum = fishPrefabs[fishPreIndex].GetComponent<FishAttr>().maxNum;
        int maxSpeed = fishPrefabs[fishPreIndex].GetComponent<FishAttr>().maxSpeed;

        int num = Random.Range((maxNum / 2) + 1, maxNum);
        int speed = Random.Range(maxSpeed / 2, maxSpeed);

        //0:直走 1：转弯
        int moveType = Random.Range(0, 2);
        //直走倾斜角
        int angOffset;
        //转弯角速度
        int angSpeed;

        if (moveType == 0)
        {
            angOffset = Random.Range(-22, 22);

            StartCoroutine(GenStraightFish(genPosIndex, fishPreIndex, num, speed, angOffset));
        }
        else
        {
            //是否取负的角度
            if (Random.Range(0,2) == 0)
            {
                angSpeed = Random.Range(-15, -9);

            }
            else
            {
                angSpeed = Random.Range(9, 15);
            }

            StartCoroutine(GenTurnFish(genPosIndex, fishPreIndex, num, speed, angSpeed));
        }
    }


    IEnumerator GenStraightFish(int genPosIndex, int fishPreIndex, int num, int speed, int angOffset)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject fish = Instantiate(fishPrefabs[fishPreIndex]);
            fish.transform.SetParent(fishHolder, false);
            fish.transform.localPosition = genPositions[genPosIndex].localPosition;
            fish.transform.localRotation = genPositions[genPosIndex].localRotation;
            fish.transform.Rotate(0, 0, angOffset);

            fish.GetComponent<SpriteRenderer>().sortingOrder += i;
            fish.AddComponent<Ef_AutoMove>().speed = speed;
            yield return new WaitForSeconds(fishGenWaitTime);
        }
    }


    IEnumerator GenTurnFish(int genPosIndex, int fishPreIndex, int num, int speed, int angSpeed)
    {
        for (int i = 0; i < num; i++)
        {
            GameObject fish = Instantiate(fishPrefabs[fishPreIndex]);
            fish.transform.SetParent(fishHolder, false);
            fish.transform.localPosition = genPositions[genPosIndex].localPosition;
            fish.transform.localRotation = genPositions[genPosIndex].localRotation;

            fish.GetComponent<SpriteRenderer>().sortingOrder += i;
            fish.AddComponent<Ef_AutoMove>().speed = speed;
            fish.AddComponent<Ef_AutoRotate>().speed = angSpeed;
            yield return new WaitForSeconds(fishGenWaitTime);
        }
    }
}