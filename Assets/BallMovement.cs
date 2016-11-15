using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour
{
    public Vector3 speed;
    public float acceleration = 0.7f;
    float friction = 0.96f;
    public float maxSpeed = 200f;
    private bool bounced = false;
    private float bounciness = 3f * 1;
    private static float MOVEMENTCONSTANT = 7f;
    private static float MOVEMENTSCALAR = 1/10f;
    public static float PUSHBACK = -2f * 1f;

    public string otherPlayerTag;

    Rigidbody rb;
    Vector3 push;
    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //player 1
        if ((Input.GetAxis("HorizontalJ") != 0 || Input.GetAxis("VerticalJ") != 0) && rb.velocity.magnitude <= maxSpeed && this.gameObject.name.Equals("Ball"))
        {
            push.x = Input.GetAxis("HorizontalJ");
            push.z = Input.GetAxis("VerticalJ");
            rb.AddForce(Time.deltaTime * push.x * new Vector3(1,0,0) * MOVEMENTCONSTANT, ForceMode.Impulse);
            rb.AddForce(Time.deltaTime * push.z * new Vector3(0,0,1) * MOVEMENTCONSTANT,ForceMode.Impulse);

        }

        //player 2
        if ((Input.GetAxis("HorizontalK") != 0 || Input.GetAxis("VerticalK") != 0) && rb.velocity.magnitude <= maxSpeed && this.gameObject.name.Equals("Ball2"))
        {
            push.x = Input.GetAxis("HorizontalK");
            push.z = Input.GetAxis("VerticalK");
            rb.AddForce(Time.deltaTime * push.x * new Vector3(1, 0, 0) * MOVEMENTCONSTANT, ForceMode.Impulse);
            rb.AddForce(Time.deltaTime * push.z * new Vector3(0, 0, 1) * MOVEMENTCONSTANT, ForceMode.Impulse);
        }

        //android controls
        if (speed.magnitude <= maxSpeed && (Input.acceleration.x != 0 || Input.acceleration.y != 0))
        {
            speed.x += Input.acceleration.x * Time.deltaTime;
            speed.z -= Input.acceleration.z * Time.deltaTime;
        }
        transform.Translate(rb.velocity);
        //transform.Rotate(speed * Time.deltaTime * Input.GetAxis("Horizontal"), 0f, speed * Time.deltaTime * Input.GetAxis("Vertical"));
        speed *= friction;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(otherPlayerTag))
        {
            Vector3 impulse = (2 * rb.velocity + col.gameObject.GetComponent<Rigidbody>().velocity);
            Vector3 impulse2 = (rb.velocity + 2 * col.gameObject.GetComponent<Rigidbody>().velocity);
            push = new Vector3(0, 0, 0);
            rb.velocity = col.contacts[0].normal * bounciness + push * PUSHBACK;
         //   col.gameObject.GetComponent<Rigidbody>().velocity = -col.contacts[0].normal * bounciness + col.gameObject.GetComponent<BallMovement>().push * PUSHBACK;
          //  col.gameObject.GetComponent<Rigidbody>().velocity = -col.contacts[0].normal * bounciness;

  //          rb.AddForce(MOVEMENTSCALAR * impulse * bounciness -push * PUSHBACK, ForceMode.VelocityChange);
  //            col.gameObject.GetComponent<Rigidbody>().AddForce(-MOVEMENTSCALAR * (impulse2 * bounciness - col.gameObject.GetComponent<BallMovement>().push * PUSHBACK),ForceMode.VelocityChange);

            print(push);
        
            bounced = true;
            //  speed = impulse * bounciness;
            //   col.gameObject.GetComponent<BallMovement>().speed = -impulse * bounciness;

            //        rb.AddForce(MOVEMENTSCALAR * (col.contacts[0].normal * bounciness + rb.velocity - col.gameObject.GetComponent<BallMovement>().push * PUSHBACK), ForceMode.Impulse);
            //      rb.velocity = impulse *  bounciness;
            // col.gameObject.GetComponent<Rigidbody>().velocity
            //col.gameObject.GetComponent<Rigidbody>().AddForce(-MOVEMENTSCALAR * (col.contacts[0].normal * bounciness + rb.velocity + push * PUSHBACK), ForceMode.Impulse);
            //          col.gameObject.GetComponent<Rigidbody>().velocity = -impulse2 * bounciness;
        }
    }
    void onCollisionExit(Collision col)
    {
        bounced = false;
    }


        /*Handle powerup collision*/

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Speedup")
        {
            print("test");
            maxSpeed *= 2;
            rb.velocity *= 2;
            Destroy(col.gameObject);
        }


    }

}
