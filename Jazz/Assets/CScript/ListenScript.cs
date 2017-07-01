using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListenScript : MonoBehaviour {
	private float[] data;
	public float AverageVolume{get{return GetAveragedVolume();}}
	// Use this for initialization
	void Start () {
		data = new float[256];
	}
	
	float GetAveragedVolume()
	{
		float a = 0;
		AudioListener.GetOutputData(data, 0);
		foreach (float s in data)
		{
			a += Mathf.Abs(s);
		}
		return a / 256;
	}
}
