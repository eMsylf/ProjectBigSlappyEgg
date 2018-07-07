using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public GameObject basket;

	// Use this for initialization
	void Start () {
        scoreText.text = "score";
	}
	
	// Update is called once per frame
	void Update () {

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameObject.tag == "P1")
        {
            Debug.Log("Player 1 gets a point");
        }
    }
}
