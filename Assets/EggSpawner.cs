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
            float delay = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(delay);

            int spawnIndex = Random.Range(0, spawnPoints.Length);
            Transform spawnPoint = spawnPoints[spawnIndex];

            int eggIndex = Random.Range(0, 2);

            if (eggIndex == 0)
            {
                GameObject spawnedEgg = Instantiate(eggYellowPrefab, spawnPoint.position, spawnPoint.rotation);
                Destroy(spawnedEgg, 4f);
            }
            if (eggIndex == 1)
            {
                GameObject spawnedEgg = Instantiate(eggRedPrefab, spawnPoint.position, spawnPoint.rotation);
                Destroy(spawnedEgg, 4f);
            }
            
        }
    }
}
