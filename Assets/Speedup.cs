using UnityEngine;
using System.Collections;

public class Speedup : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Ball2")
        {
            print("test");
            Ball2Movement other = (Ball2Movement)GameObject.Find("Ball2").GetComponent(typeof(Ball2Movement));
            other.maxSpeed *= 2;
            other.speed *= 2;
        }
        if (col.gameObject.name == "Ball")
        {
            print("test");
            BallMovement other = (BallMovement)GameObject.Find("Ball").GetComponent(typeof(BallMovement));
            other.maxSpeed *= 2;
            other.speed *= 2;
        }

        Destroy(this.gameObject);

    }
}
