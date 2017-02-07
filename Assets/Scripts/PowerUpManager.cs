using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour {
    public int spawned = 0;
    public int numToSpawn = 1;
    static GameObject spd;
    // Use this for initialization
    void Start () {
        spawned = 0;
        numToSpawn = 1;
        spd = GameObject.Find("Speedup");
    }
	
	// Update is called once per frame
	void Update () {
		if (spawned < numToSpawn)
        {
         //   GameObject spd = GameObject.Find("Speedup");
            Vector3 pos = new Vector3(Random.Range(-40f, 40f), 58, Random.Range(-30f, 80f));
            spd.transform.position = pos;
            spawned++;
            StartCoroutine(spawnWait());

        }
	}

    IEnumerator spawnWait()
    {
        yield return new WaitForSeconds(2);
        spd.SetActive(true);
    }
}
