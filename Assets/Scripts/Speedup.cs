using UnityEngine;
using System.Collections;

public class Speedup : MonoBehaviour {
    public Collider speedupCollider;
	// Use this for initialization
	void Start () {
        Vector3 pos = new Vector3(Random.Range(-40f, 40f), 58, Random.Range(-30f, 80f));
        this.transform.position = pos;
        //    Destroy(this.gameObject);
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "RedBall")
        {
            BallMovement other = (BallMovement)GameObject.Find("RedBall").GetComponent(typeof(BallMovement));
            other.boost= 100;
            PlayerBoost pb = (PlayerBoost)GameObject.Find("RedBoostBar").GetComponent(typeof(PlayerBoost));
            pb.fillBar();
            Vector3 pos = new Vector3(Random.Range(-40f, 40f), 58, Random.Range(-30f, 80f));

        }
        if (col.gameObject.name == "BlueBall")
        {
            BallMovement other = (BallMovement)GameObject.Find("BlueBall").GetComponent(typeof(BallMovement));
            other.boost = 100;
            PlayerBoost pb = (PlayerBoost)GameObject.Find("BlueBoostBar").GetComponent(typeof(PlayerBoost));
            pb.fillBar();
        }

        this.gameObject.SetActive(false);
        GameObject.Find("Canvas").GetComponent<PowerUpManager>().spawned--;
    }
}
