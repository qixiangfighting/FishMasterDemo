using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAttr : MonoBehaviour
{

    public int speed;
    public int damage;

    public GameObject webPrefab;


    private void OnTriggerEnter2D(Collider2D collosion)
    {
        if (collosion.tag == "Border")
        {
            Destroy(gameObject);
        }

        if (collosion.tag == "Fish")
        {

            GameObject web = Instantiate(webPrefab);
            web.transform.SetParent(gameObject.transform.parent, false);
            web.transform.position = gameObject.transform.position;
            Destroy(gameObject);
        }
    }
}
