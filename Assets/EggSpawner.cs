using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggSpawner : MonoBehaviour {

    public GameObject eggYellowPrefab;
    public GameObject eggRedPrefab;
    public Transform[] spawnPoints;
    
    public float minDelay = .1f;
    public float maxDelay = 1f;
    

	// Use this for initialization
	void Start () {
        StartCoroutine(SpawnEggs());
	}
	
    IEnumerator SpawnEggs ()
    {
        while (true)
        {
            
            // Create random delay between spawns
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            // Randomly choose between spawnpoints
            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            // Pick one of two kinds of eggs (yellow or red)
            int eggIndex = Random.Range(0, 2);
            if (eggIndex == 0)
            {
                GameObject spawnedEggYellow = Instantiate(eggYellowPrefab, spawnPoint.position, spawnPoint.rotation);
                Destroy(spawnedEggYellow, 3f);
            }
            if (eggIndex == 1)
            {
                GameObject spawnedEggRed = Instantiate(eggRedPrefab, spawnPoint.position, spawnPoint.rotation);
                Destroy(spawnedEggRed, 3f);
            }
        }
    }
}
