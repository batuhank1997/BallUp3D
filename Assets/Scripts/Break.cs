using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break : MonoBehaviour
{
    public GameObject breakObj;
    public GameObject explotion;
    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject.tag == "Red")
        {
            if (collision.gameObject.tag == "Red")
            {
                Instantiate(breakObj, transform.position, Quaternion.identity);
                Handheld.Vibrate();
                collision.gameObject.tag = "Player";
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "Green")
        {
            if (collision.gameObject.tag == "Green")
            {
                Instantiate(breakObj, transform.position, Quaternion.identity);
                Handheld.Vibrate();
                collision.gameObject.tag = "Player";
                Destroy(gameObject);
            }
        }
        else if (gameObject.tag == "Blue")
        {
            if (collision.gameObject.tag == "Blue")
            {
                Instantiate(breakObj, transform.position, Quaternion.identity);
                Handheld.Vibrate();
                collision.gameObject.tag = "Player";
                Destroy(gameObject);
            }
        }

        else if(collision.gameObject.tag == "Player")
        {
            Instantiate(explotion, collision.gameObject.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
        }
    }
}
