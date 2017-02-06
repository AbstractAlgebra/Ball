using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class PlayerBoost : MonoBehaviour {
    private float fillAmount;
    float boost = 100;

    [SerializeField]
    private Image content;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        HandleBar();
	}

    public void fillBar()
    {
        boost = 100;
        content.fillAmount = Map(boost, 0, 100, 0, 1);
    }

    private void HandleBar()
    {
        if ((Input.GetKey(KeyCode.E) && this.gameObject.name.Equals("BlueBoostBar")))
        {
            boost = GameObject.Find("BlueBall").GetComponent<BallMovement>().boost--;
            if (boost != 0)
            {
                GameObject.Find("BlueBall").GetComponent<BallMovement>().isBoosting = true;
            }
        }
        if ((Input.GetKeyUp(KeyCode.E) && this.gameObject.name.Equals("BlueBoostBar")))
        {
            GameObject.Find("BlueBall").GetComponent<BallMovement>().isBoosting = false;
        }


        if ((Input.GetKey(KeyCode.Q) && this.gameObject.name.Equals("RedBoostBar")))
        {
            boost = GameObject.Find("RedBall").GetComponent<BallMovement>().boost--;
            if (boost != 0)
            {
                GameObject.Find("RedBall").GetComponent<BallMovement>().isBoosting = true;
            }
        }

        if ((Input.GetKeyUp(KeyCode.Q) && this.gameObject.name.Equals("RedBoostBar")))
        {
            GameObject.Find("RedBall").GetComponent<BallMovement>().isBoosting = false;
        }

        content.fillAmount = Map(boost,0,100,0,1);
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
