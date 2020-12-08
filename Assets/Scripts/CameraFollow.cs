using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    private Vector3 offset1;
    private Vector3 offset2;
    public float smoothTime;
    public float maxSpeed;
    public float speed;
    private Vector3 velocity = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        offset1 = new Vector3(0, -10, -15);
        offset2 = new Vector3(0, -15, -5);
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;
        if(GameManager.I.shootRegion == false)
            transform.position = new Vector3(0, target.position.y + offset1.y, offset1.z);
        else if(GameManager.I.shootRegion == true)
        {
            transform.position = Vector3.SmoothDamp(transform.position, new Vector3(0, target.position.y + offset2.y, offset2.z), ref velocity, smoothTime, maxSpeed);
            transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation * Quaternion.Euler(-90,0,0), speed * Time.deltaTime);
        }
    }
}
