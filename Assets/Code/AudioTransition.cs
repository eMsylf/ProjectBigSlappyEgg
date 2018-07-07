using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioTransition : MonoBehaviour
{
    public AudioMixer mixer;

    private AudioMixerSnapshot normalSnapshot;
    //private AudioMixerSnapshot lowVolumeSnapshot;
    private AudioMixerSnapshot muteSnapshot;

	// Use this for initialization
	void Start ()
    {
        normalSnapshot = mixer.FindSnapshot("Normal");
        //lowVolumeSnapshot = mixer.FindSnapshot("LowVolume");
        muteSnapshot = mixer.FindSnapshot("Mute");
	}
	
	// Update is called once per frame
	void Update ()
    { 
		if(Input.GetKeyDown(KeyCode.M))
        {
            mixer.ClearFloat("MasterVolume");
            muteSnapshot.TransitionTo(.5f);
        }
        else if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            mixer.ClearFloat("MasterVolume");
            normalSnapshot.TransitionTo(.5f);
        }

        else if(Input.GetMouseButton(0))
        {
            float currentVolume;
            mixer.GetFloat("MasterVolume", out currentVolume);
            mixer.SetFloat("MasterVolume", currentVolume + .1f);
        }

        else if (Input.GetMouseButton(1))
        {
            float currentVolume;
            mixer.GetFloat("MasterVolume", out currentVolume);
            mixer.SetFloat("MasterVolume", currentVolume - .1f);
        }
	}
}
