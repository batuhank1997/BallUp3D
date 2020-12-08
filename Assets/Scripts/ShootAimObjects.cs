using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootAimObjects : MonoBehaviour
{
    public float speed;
    [SerializeField]
    private float changeDirection = 0;
    private Rigidbody rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        if(gameObject.tag == "VerticalAim")
        {
            if (changeDirection % 2 == 0)
                rb.velocity = new Vector3(0, 0, speed);
            if (changeDirection % 2 != 0)
                rb.velocity = new Vector3(0, 0, -speed);
            
        }
        else if(gameObject.tag == "HorizontalAim")
        {
            if (changeDirection % 2 == 0)
                rb.velocity = new Vector3(speed, 0, 0);
            if (changeDirection % 2 != 0)
                rb.velocity = new Vector3(-speed, 0, 0);
            
        }

        if (Input.GetMouseButtonDown(0))
        {
            rb.velocity = Vector3.zero;
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Checker")
        {
            changeDirection++;
        }
    }
}
