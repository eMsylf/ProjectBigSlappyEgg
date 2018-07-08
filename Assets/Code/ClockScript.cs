using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClockScript : MonoBehaviour {

    public Text clockText;

    int startTime = 3;
    int time;

    // Use this for initialization
    void Start () {
        time = startTime;
        StartCoroutine("CountdownTime");
	}
	
	// Update is called once per frame
	void Update () {
        clockText.text = time.ToString();

        if (time == 0)
        {
            StopCoroutine("CountdownTime");

            Time.timeScale = Mathf.Lerp(1f, .1f, .5f);
        }
	}

    IEnumerator CountdownTime ()
    {
        while (time > 0)
        {
            yield return new WaitForSeconds(1);
            time--;
            Debug.Log(time);
        }
    }
}
