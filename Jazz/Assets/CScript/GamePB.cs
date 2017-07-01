using UnityEngine;

[CreateAssetMenu (menuName = "GamePrefeb_List")]
public class GamePB : ScriptableObject {
	[SerializeField] GameObject _BlockManager;
	public GameObject BlockManager{get{return _BlockManager;}}
	[SerializeField] GameObject _PlayerManager;
	public GameObject PlayerManager{get{return _PlayerManager;}}
	[SerializeField] GameObject _AudioBlock;
	public GameObject AudioBlock{get{return _AudioBlock;}}
}
