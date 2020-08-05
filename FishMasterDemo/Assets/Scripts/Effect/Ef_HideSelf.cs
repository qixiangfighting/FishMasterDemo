using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class Ef_HideSelf : MonoBehaviour
{


    public IEnumerator HideSelf(float delay)
    {
        yield return  new WaitForSeconds(delay);

        gameObject.SetActive(false);
    }

}
