using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeWithSound : MonoBehaviour {
	[Header("SCALE SPEED")]
	[SerializeField] float RespondSpeed = 1.0f;
	[SerializeField] float FadeSpeed = 1.0f;
	public bool ifActivated = false;
	// Use this for initialization
	void Start () {
		transform.localScale = new Vector3(1,0,1);
	}
	
	// Update is called once per frame
	void Update () {
		// GetComponent<AudioSource>().GetOutputData(0,0);
	}

	public IEnumerator ScaleChange(){
		float MAX = Random.Range(10.0f, 40.0f);
		Vector3 originalScale = transform.localScale;
		ifActivated = true;

		for(float i = 0; transform.localScale.y < MAX; i += Time.deltaTime * RespondSpeed){
			// transform.localScale = new Vector3(transform.localScale.x, i, 1);
			transform.localScale = Vector3.Lerp(originalScale, new Vector3(originalScale.x, MAX, 1), i);
			yield return null;
		}

		originalScale = transform.localScale;
		for(float i = 0;  transform.localScale.y > 0; i += Time.deltaTime * FadeSpeed){
			transform.localScale = Vector3.Lerp(originalScale, new Vector3(originalScale.x, 0, 1), i);
			yield return null;
		}

		ifActivated = false;
	}
}
