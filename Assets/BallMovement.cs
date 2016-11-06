using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour
{
    public Vector3 speed;
    public float acceleration = 0.7f;
    float friction = 0.96f;
    public float maxSpeed = 28f;
    public bool bounce;
    public float bounciness = 1000.0f;

    public string otherPlayerTag;

    Rigidbody rb;

    // Use this for initialization
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //player 1
        if ((Input.GetAxis("HorizontalJ") != 0 || Input.GetAxis("VerticalJ") != 0) && speed.magnitude <= maxSpeed && this.gameObject.name.Equals("Ball"))
        {
            speed.x += Time.deltaTime * Input.GetAxis("HorizontalJ");
            speed.z += Time.deltaTime * Input.GetAxis("VerticalJ");
            print(4);
        }

        //player 2
        if ((Input.GetAxis("HorizontalK") != 0 || Input.GetAxis("VerticalK") != 0) && speed.magnitude <= maxSpeed && this.gameObject.name.Equals("Ball2"))
        {
            speed.x += Time.deltaTime * Input.GetAxis("HorizontalK");
            speed.z += Time.deltaTime * Input.GetAxis("VerticalK");
        }

        //android controls
        if (speed.magnitude <= maxSpeed && (Input.acceleration.x != 0 || Input.acceleration.y != 0))
        {
            speed.x += Input.acceleration.x * Time.deltaTime;
            speed.z -= Input.acceleration.z * Time.deltaTime;
        }
        transform.Translate(speed);
        bounce = false;
        //transform.Rotate(speed * Time.deltaTime * Input.GetAxis("Horizontal"), 0f, speed * Time.deltaTime * Input.GetAxis("Vertical"));
        speed *= friction;
    }
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag(otherPlayerTag))
        {
             Vector3 impulse = (2 * speed + col.gameObject.GetComponent<BallMovement>().speed);
            print(impulse);
           //  speed = impulse * bounciness;
             //col.gameObject.GetComponent<BallMovement>().speed = -impulse * bounciness;

         rb.AddForce(col.contacts[0].normal * bounciness, ForceMode.VelocityChange);
         rb.velocity = impulse *  bounciness;
            col.gameObject.GetComponent<Rigidbody>().velocity = -impulse * bounciness;
        }


    }

}
