using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ef_WaterWave : MonoBehaviour
{
    public Texture[] texttures;

    private Material material;

    private int index = 0;


    void Start()
    {
        material = GetComponent<MeshRenderer>().material;
        InvokeRepeating("ChangeTextture", 0, 0.1f);
    }

    void ChangeTextture()
    {
        material.mainTexture = texttures[index];
        index = (index + 1) % texttures.Length;
    }
}