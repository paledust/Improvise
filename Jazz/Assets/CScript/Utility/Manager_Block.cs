using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager_Block : MonoBehaviour {
	[SerializeField] List<GameObject> Blocks;
	void Start(){
	}
	void Update(){
		
	}
	public void CreateBlock(Vector3 pos = default(Vector3), Quaternion rot = default(Quaternion)){
		Blocks.Add(Instantiate(service.prefebList.AudioBlock, pos, rot, transform) as GameObject);
	}
	public void Destroy(GameObject block){
		if(Blocks.Contains(block)){
			Blocks.Remove(block);
		}
		Destroy(block);
	}
	public GameObject GetBlock(){
		return Blocks[Random.Range(0, Blocks.Count)];
	}
}
