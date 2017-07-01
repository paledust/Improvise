using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Kevin_Event;

public class PressPlay : MonoBehaviour {
	[SerializeField] int UpdateRate = 1;

	[Header("Threashold")]
	[SerializeField] float Quick = 1;
	[SerializeField] float Mid = 1;
	[SerializeField] float Slow = 1;
	[Space (10)]

	[Header("SoundCurve")]
	[SerializeField] AnimationCurve QuickCurve;

	private float timer = 0.0f;
	private float UpdateTime = 0.0f;
	private float PressTime = 0.0f;
	static private int _note_index;
	static public int note_index{
		get{
		return _note_index;
	} 
		set{
		_note_index = value;
		if(value >= 7){
			_note_index = 7;
		}
		if(value <= 0){
			_note_index = 0;
		}
	}}

	void Start(){
		timer = 0.0f;
		UpdateTime = 0.0f;
		PressTime = 0.0f;
		note_index = 0;

		service.eventManger.RegistHandler<ShiftNote_Event>(ShiftNoteHandler);
		service.eventManger.RegistHandler<LowerNote_Event>(LowerNoteHandler);

	}
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if(timer - UpdateTime > 1/UpdateRate){
			UpdateTime = timer;
			RateUpdate();
		}
	}

	void RateUpdate(){
		if(Input.anyKeyDown){
			if(UpdateTime - PressTime <= 1.0f/Quick){
				QuickCheck();
			}
			else if(UpdateTime - PressTime <= 1.0f/Mid){
				MidCheck();
			}
			else if(UpdateTime - PressTime <= 1.0f/Slow){
				SlowCheck();
			}
			else
				SuperSlowCheck();
		}
	}

	void QuickCheck(){
		service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.ZhengAudios[note_index], 1.0f, 1.5f + QuickCurve.Evaluate((UpdateTime - PressTime)*Quick));
		switch (note_index)
		{	
			case 1:
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[0], 1.0f);
				break;
			case 2:
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[0], 1.0f);
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[0],1.0f, 1.5f);
				break;
			case 3:
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[0],1.0f, 1.0f);
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[0],1.0f, 1.5f);
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[0],1.0f, 0.5f);
				break;
			case 4:
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[0],1.0f, 1.0f);
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[0],1.0f, 1.5f);
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[0],1.0f, 0.5f);
				break;
			case 5:
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[0],1.0f, 1.0f);
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[0],1.0f, 1.5f);
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[1],1.0f, 0.5f);
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[1],1.0f, 1.0f);
				break;
			case 6:
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[0],1.0f, 1.0f);
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[3],1.0f, 1.5f);
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[0],1.0f, 0.5f);
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[2],1.0f, 1f);
				break;
			case 7:
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[0],1.0f, 1.0f);
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[1],1.0f, 1f);
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[3],0.7f, 1f);
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumMidAudios[2],1.0f, 1f);
				service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.DrumBigAudios[0]);
				break;
			default:
				break;
		}
		PressTime = UpdateTime;
	}
	void MidCheck(){
		service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.ZhengAudios[note_index], 1.0f,1.5f);
		PressTime = UpdateTime;
	}
	void SlowCheck(){
		service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.ZhengAudios[note_index], 0.8f,1.0f);
		PressTime = UpdateTime;
	}
	void SuperSlowCheck(){
		service.BlockManager.GetBlock().GetComponent<AudioManager>().PlayAudio(service.audioList.ZhengAudios[note_index], 1.0f,1.0f);
		PressTime = UpdateTime;
	}

	void ShiftNoteHandler(Kevin_Event.Event e){
		int i = note_index;
		note_index ++;
	}

	void LowerNoteHandler(Kevin_Event.Event e){
		note_index --;
	}
	
}
