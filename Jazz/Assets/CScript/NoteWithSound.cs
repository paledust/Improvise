using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteWithSound : MonoBehaviour {
	// Use this for initialization
	ListenScript listener;
	[SerializeField] float LoudThreashold;
	[SerializeField] float LowThreashold;

	[SerializeField] private float LoudTimer = 0.0f;
	[SerializeField] private float LowTimer = 0.0f;
	void Start () {
		LoudTimer = 0.0f;
		LowTimer = 0.0f;
		listener = GetComponent<ListenScript>();	
	}

	// Update is called once per frame
	void Update () {
		if(listener.AverageVolume >= LoudThreashold){
			LoudTimer += Time.deltaTime;
			Debug.Log("loud");
			if(LoudTimer >= 3.0f){
				LoudTimer = 0.0f;
				Kevin_Event.ShiftNote_Event tempevent = new Kevin_Event.ShiftNote_Event();
				service.eventManger.FireEvent(tempevent);
			}
		}
		else{
			if(LoudTimer >= 0.0f)
				LoudTimer -= Time.deltaTime;
		}

		if(listener.AverageVolume <= LowThreashold){
			LowTimer += Time.deltaTime;
			if(LowTimer >= 5.0f){
				LowTimer = 0.0f;
				Kevin_Event.LowerNote_Event tempevent = new Kevin_Event.LowerNote_Event();
				service.eventManger.FireEvent(tempevent);
			}
		}
		else{
			if(LowTimer >= 0.0f)
				LowTimer -= Time.deltaTime;
		}
	}
}
