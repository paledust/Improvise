using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
	AudioSource audioSource;
	SizeWithSound sizeSound;
	// Use this for initialization
	void Start () {
		if(audioSource == null){
			gameObject.AddComponent<AudioSource>();
		}
		audioSource = GetComponent<AudioSource>();
		sizeSound = GetComponent<SizeWithSound>();
		audioSource.playOnAwake = false;
		audioSource.loop = false;
	}

	public void PlayAudio(AudioClip audio, float volume = 1.0f, float pitch = 1.0f){
		audioSource.volume = volume;
		audioSource.pitch = pitch;
		audioSource.PlayOneShot(audio);

		StopAllCoroutines();
		StartCoroutine(sizeSound.ScaleChange());
	}
}
