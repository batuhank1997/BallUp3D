using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointScore : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(2, 2, 2);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            GameManager.I.blueBoxes++;
        }
    }
}
