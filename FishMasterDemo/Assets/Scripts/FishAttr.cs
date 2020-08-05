using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishAttr : MonoBehaviour
{
    public int maxNum;
    public int maxSpeed;

    public GameObject diePrefab;
    public int hp;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Border")
        {
            Destroy(gameObject);
        }
    }

    void TakeDamage(int value)
    {
        hp -= value;

        if (hp <= 0)
        {
            GameObject die = Instantiate(diePrefab);
            die.transform.SetParent(gameObject.transform.parent, false);
            die.transform.position = transform.position;
            die.transform.rotation = transform.rotation;
            Destroy(gameObject);
        }
    }
}