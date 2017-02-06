using UnityEngine;
using UnityEngine.UI;
using System.Collections;



public class PlayerBoost : MonoBehaviour {
    private float fillAmount;
    int i = 100;

    [SerializeField]
    private Image content;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        HandleBar();
	}

    private void HandleBar()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            i--;
        }
        content.fillAmount = Map(i,0,100,0,1);
    }

    private float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}
