using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{


    public float forwardMovementSpeed;
    public float turnSpeed;
    private float screenCenterX;
    public float pivotForce;
    public float waitTime;
    public float wifeFallTreshold, throwPower;
    public Rigidbody rb;
   // public Rigidbody rb;
    public bool debugEnabled, isFallen;
    private bool toggle;
    public GameController gameController;
    public GameObject fallChecker;
    private Vector3 fallStartLoc;
    private Vector3 deltaVector;
    // Use this for initialization
    void Start()
    {
        screenCenterX = Screen.width * 0.5f;
        fallChecker = GameObject.Find("FallChecker");

        toggle = true;
        gameController = FindObjectOfType(typeof(GameController)) as GameController;

        rb = transform.Find("Avatar").gameObject.GetComponent<Rigidbody>();
        isFallen = false;
        fallStartLoc = fallChecker.transform.position;

       // rb.centerOfMass = fallChecker.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

       

        if (!rb)
        {
            rb = transform.Find("Avatar").gameObject.GetComponent<Rigidbody>();
        }


        //deltaVector = fallStartLoc - rb.gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (toggle)
            {
                debugEnabled = true;
                toggle = false;
            }


            else if (!toggle)
            {
                debugEnabled = false;
                toggle = true;
            }
        }


        if (!debugEnabled || !isFallen)
        {

           
            transform.Translate(Vector3.forward * forwardMovementSpeed);

            if (Input.touchCount > 0)
            {
                Debug.Log("Touch count: " + Input.touchCount);
                // get the first one
                Touch firstTouch = Input.GetTouch(0);

                // if it began this frame

                if (firstTouch.position.x > screenCenterX)
                {
                    // if the touch position is to the right of center
                    // move right

                    //rb.velocity = Vector3.right * turnSpeed;
                    transform.Translate(Vector3.right * turnSpeed);
                    //rb.AddForce(Vector3.right * pivotForce, ForceMode.Force);


                }
                else if (firstTouch.position.x < screenCenterX)
                {
                    // if the touch position is to the left of center
                    // move left

                    //rb.velocity = Vector3.left * turnSpeed;
                    transform.Translate(Vector3.left * turnSpeed);
                    //rb.AddForce(Vector3.left * pivotForce, ForceMode.Force);


                }

            }

            if (Mathf.Abs(transform.rotation.z) > (wifeFallTreshold))
            {
                isFallen = true;
            }
        }

        if (isFallen)
        {
            Debug.Log("Fallen");
            StartCoroutine(GettingUp());
        }

        if (debugEnabled)
        {

            if (Input.GetKey(KeyCode.W))
            {
                ////rb.velocity = Vector3.forward * turnSpeed;

                transform.Translate(Vector3.forward * forwardMovementSpeed);
            }

            if (Input.GetKey(KeyCode.D))
            {
                ////rb.velocity = Vector3.right * turnSpeed;
                transform.Translate(Vector3.right * turnSpeed);
                //leftPivotRb.AddForce(Vector3.down * pivotForce, ForceMode.Acceleration);
                //rightPivotRb.AddForce(Vector3.up * (pivotForce / 2), ForceMode.Acceleration);
                //rb.AddForce(Vector3.right * pivotForce, ForceMode.Force);
                //transform.Rotate(Vector3.right * pivotForce);
            }

            if (Input.GetKey(KeyCode.A))
            {
                ////rb.velocity = Vector3.left * turnSpeed;
                transform.Translate(Vector3.left * turnSpeed);
                //rightPivotRb.AddForce(Vector3.down * pivotForce, ForceMode.Acceleration);
                //leftPivotRb.AddForce(Vector3.up * (pivotForce/2), ForceMode.Acceleration);
                //rb.AddForce(Vector3.left * pivotForce, ForceMode.Force);
                //transform.Rotate(Vector3.left * pivotForce);
            }

            if (Input.GetKeyDown(KeyCode.R))
            {
                gameController.GoToGameScene();
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Goal")
        {
            transform.DetachChildren();
           //rb.AddForce(Vector3.up * throwPower, ForceMode.Impulse);
            gameController.GoToScoreScene();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(this.GetComponent<Collider>(), collision.gameObject.GetComponent<Collider>());
        }

        if (collision.gameObject.tag == "Ground")
        {
            fallStartLoc = fallChecker.transform.position;
        }
    }

    IEnumerator GettingUp()
    {
        yield return new WaitForSeconds(waitTime);

        Instantiate(gameController.player, this.transform.position, Quaternion.identity);
        Destroy(this.gameObject);

    }


}
