using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText_P1;
    public Text scoreText_P2;
    public BoxCollider2D basketInnerCollider;
    public int score_P1 = 0;
    public int score_P2 = 0;

    public int score_P1Final;
    public int score_P2Final;

	// Use this for initialization
	void Start () {
        basketInnerCollider.GetComponent<BoxCollider2D>();
    }
	
	// Update is called once per frame
	void Update () {
            scoreText_P1.text = score_P1.ToString();
            scoreText_P2.text = score_P2.ToString();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "P1")
        {
            score_P1++;
            //Debug.Log("Player 1 gets a point. Total: " + score_P1);
        }
        else if (collision.gameObject.tag == "P2")
        {
            score_P2++;
            //Debug.Log("Player 2 gets a point. Total: " + score_P2);
        }
    }
}
