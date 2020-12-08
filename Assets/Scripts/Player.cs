using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    public float shootSpeed;
    public bool directionCheck;
    public bool shot = false;
    private Vector3 upSpeed;
    public GameObject explotion;
    public GameObject finishExplotion;
    public GameObject scoreHit;
    public GameObject x5Anim;
    public GameObject x3Anim;
    public GameObject x2Anim;
    public GameObject outAnim;

    public GameObject vercitalAim;
    public GameObject horizontalAim;
    private Transform targetTransform;
    private Material playerMaterial;
    public GameObject targetBoard;

    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.I.player = gameObject;

        rb = GetComponent<Rigidbody>();
        upSpeed = Vector3.zero;
        targetTransform = new GameObject().transform;
        playerMaterial = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.I.gameStart)
        {
            if (GameManager.I.shootRegion == false)
            {
                upSpeed = Vector3.up * speed * 2;

                if (Input.GetMouseButtonDown(0))
                {
                    if (directionCheck == true)
                        directionCheck = false;
                    else if (directionCheck == false)
                        directionCheck = true;
                }

                if (directionCheck)
                {
                    rb.velocity = upSpeed + Vector3.right * speed;
                }
                if (!directionCheck)
                {
                    rb.velocity = upSpeed + Vector3.left * speed;
                }
            }
            else if(GameManager.I.shootRegion == true)
            {
                //do magic
                rb.velocity = Vector3.zero;

                if(vercitalAim != null)
                    vercitalAim.SetActive(true);

                Aim();

                if (shot == true)
                    rb.AddForce((targetTransform.position - transform.position) * shootSpeed * Time.deltaTime, ForceMode.Force);
                    //transform.position = Vector3.MoveTowards(transform.position, targetTransform.position, shootSpeed);

            }
        }
    }

    void Aim()
    {
        StartCoroutine(Wait2());
    }

    void Shoot()
    {
        shot = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Obstacle")
        {
            GameManager.I.gameOver = true;
            Instantiate(explotion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if(gameObject.tag == "Player")
        {
            if (collision.gameObject.tag == "Red" || collision.gameObject.tag == "Green" || collision.gameObject.tag == "Blue")
            {
                GameManager.I.gameOver = true;
                Instantiate(explotion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        if (collision.gameObject.tag == "InnerCircle")
        {
            Instantiate(finishExplotion, transform.position, Quaternion.identity);
            Debug.Log("Inner Hit!");
            x5Anim.SetActive(true);
            GameManager.I.blueBoxes *= 5;
            StartCoroutine(Wait());
        }
        if (collision.gameObject.tag == "MiddleCircle")
        {
            Instantiate(finishExplotion, transform.position, Quaternion.identity);
            Debug.Log("Middle Hit!");
            x3Anim.SetActive(true);
            GameManager.I.blueBoxes *= 3;
            StartCoroutine(Wait());
        }
        if (collision.gameObject.tag == "OuterCircle")
        {
            Instantiate(finishExplotion, transform.position, Quaternion.identity);
            Debug.Log("Outer Hit!");
            x2Anim.SetActive(true);
            GameManager.I.blueBoxes *= 2;
            StartCoroutine(Wait());
        }
        if(collision.gameObject.tag == "Miss")
        {
            Instantiate(explotion, transform.position, Quaternion.identity);
            Debug.Log("Miss!!");
            outAnim.SetActive(true);
            StartCoroutine(Wait());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "ScorePoint")
            Instantiate(scoreHit, transform.position, Quaternion.identity);
        if(other.gameObject.tag == "Red")
        {
            gameObject.GetComponent<MeshRenderer>().material = other.gameObject.GetComponent<MeshRenderer>().material;
            gameObject.tag = "Red";
            Destroy(other.gameObject);
            StartCoroutine(Wait3());
        }
        if (other.gameObject.tag == "Green")
        {
            gameObject.GetComponent<MeshRenderer>().material = other.gameObject.GetComponent<MeshRenderer>().material;
            gameObject.tag = "Green";
            Destroy(other.gameObject);
            StartCoroutine(Wait3());
        }
        if (other.gameObject.tag == "Blue")
        {
            gameObject.GetComponent<MeshRenderer>().material = other.gameObject.GetComponent<MeshRenderer>().material;
            gameObject.tag = "Blue";
            Destroy(other.gameObject);
            StartCoroutine(Wait3());
        }
    }
    IEnumerator Wait3()
    {
        yield return new WaitForSeconds(3f);
        gameObject.GetComponent<MeshRenderer>().material = playerMaterial;
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(1f);
        GameManager.I.gameFinish = true;
        Destroy(x5Anim);
        Destroy(x3Anim);
        Destroy(x2Anim);
        Destroy(outAnim);
        Destroy(gameObject);
    }
    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(0.5f);

        if (Input.GetMouseButtonDown(0) && vercitalAim != null)
        {
            targetTransform.position = new Vector3(0, 0, vercitalAim.transform.position.z);
            Destroy(vercitalAim);

            if (horizontalAim != null)
                horizontalAim.SetActive(true);
        }
        if (vercitalAim == null && Input.GetMouseButtonDown(0) && horizontalAim != null)
        {
            targetTransform.position = new Vector3(horizontalAim.transform.position.x, targetBoard.transform.position.y, targetTransform.position.z);
            Destroy(horizontalAim);
            Debug.Log(targetTransform.position);

            Shoot();
        }
    }
}
