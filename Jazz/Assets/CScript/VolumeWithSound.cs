using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolumeWithSound : MonoBehaviour {
	private AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource>();
		audio.volume = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {
		audio.volume = Mathf.Lerp(audio.volume, 1.0f/4.0f * PressPlay.note_index, Time.deltaTime);
	}
}
