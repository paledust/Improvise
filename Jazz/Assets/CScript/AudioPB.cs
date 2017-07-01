using UnityEngine;

[CreateAssetMenu (menuName = "Audio_List")]
public class AudioPB : ScriptableObject {
	[SerializeField] AudioClip[] _DrumBigAudios;
	public AudioClip[] DrumBigAudios{get{return _DrumBigAudios;}}
	[SerializeField] AudioClip[] _DrumMidAudios;
	public AudioClip[] DrumMidAudios{get{return _DrumMidAudios;}}
	[SerializeField] AudioClip[] _ZhengAudios;
	public AudioClip[] ZhengAudios{get{return _ZhengAudios;}}
	[SerializeField] AudioClip[] _BackGroundAudios;
	public AudioClip[] BackGround{get{return _BackGroundAudios;}}
}
