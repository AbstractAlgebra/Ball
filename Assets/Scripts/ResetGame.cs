using UnityEngine;
using System.Collections;

public class ResetGame : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        BallMovement ball1 = (BallMovement)GameObject.Find("BlueBall").GetComponent(typeof(BallMovement));
        BallMovement ball2 = (BallMovement)GameObject.Find("RedBall").GetComponent(typeof(BallMovement));
        if (ball1.transform.position.y < -5 || ball2.transform.position.y < -5)
        {
            resetGame();
        }
    
    }

    void resetGame()
    {
        BallMovement ball1 = (BallMovement)GameObject.Find("BlueBall").GetComponent(typeof(BallMovement));
        BallMovement ball2 = (BallMovement)GameObject.Find("RedBall").GetComponent(typeof(BallMovement));
        ball1.transform.position = new Vector3(32.2f, 8f, -2f);
            ball2.transform.position = new Vector3(-49.5f, 9.7f, -2f);
        ball1.speed = new Vector3(0,0,0);
        ball2.speed = new Vector3(0,0,0);
        ball1.acceleration = 0;
        ball2.acceleration = 0;
        print("resettingGame");
        Application.LoadLevel(0);
    }
}
