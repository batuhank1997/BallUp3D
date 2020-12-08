using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explotion : MonoBehaviour
{
    void Start()
    {
        if(gameObject.tag == "ScoreHit")
            StartCoroutine(Destroy());
    }
    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
