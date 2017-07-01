using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		Instantiate(service.prefebList.PlayerManager);
		service.BlockManager = Instantiate(service.prefebList.BlockManager).GetComponent<Manager_Block>();
		service.eventManger = new EventManager();
		for(int i = 0; i <= 10; i++){
			service.BlockManager.CreateBlock(Vector3.right*6 + Vector3.up * (i-5), Quaternion.Euler(0,0,90));
		}
		for(int i = 0; i <= 10; i++){
			service.BlockManager.CreateBlock(Vector3.left*6 + Vector3.up * (i-5), Quaternion.Euler(0,0,90));
		}
		for(int i = 0; i <= 10; i++){
			service.BlockManager.CreateBlock(Vector3.up*6 + Vector3.right * (i-5));
		}
		for(int i = 0; i <= 10; i++){
			service.BlockManager.CreateBlock(Vector3.down*6 + Vector3.right * (i-5));
		}

		int image_index = Random.Range(0,3);
		switch (image_index)
		{	
			case 0:
				Instantiate(Resources.Load("Prefeb/Font"));
				break;
			case 1:
				Instantiate(Resources.Load("Prefeb/Self"));
				break;
			case 2:
				Instantiate(Resources.Load("Prefeb/Hand"));
				break;
			default:
				break;
		}
	}
}
