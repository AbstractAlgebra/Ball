using UnityEngine;
using System.Collections;

public class Speedup : MonoBehaviour {
    public Collider speedupCollider;
	// Use this for initialization
	void Start () {
        Destroy(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

 /*   void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "Ball2")
        {
            print("test");
            BallMovement other = (BallMovement)GameObject.Find("Ball2").GetComponent(typeof(BallMovement));
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

    }*/
}
