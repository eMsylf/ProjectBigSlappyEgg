using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

    static AudioScript musicPlayer;

    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if (musicPlayer == null)
        {
            musicPlayer = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void DestroyMusic()
    {
        Destroy(GameObject.FindGameObjectWithTag("MusicPlayer"));
    }
}
