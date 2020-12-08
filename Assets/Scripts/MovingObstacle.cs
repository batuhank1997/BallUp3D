using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObstacle : MonoBehaviour
{
    private Rigidbody rb;
    public bool touch = false;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (touch == true)
            rb.velocity = new Vector3(speed, 0, 0);
        if (touch == false)
            rb.velocity = new Vector3(-speed, 0, 0);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (touch == true)
            touch = false;
        else if (touch == false)
            touch = true;
    }
}
