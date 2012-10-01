using UnityEngine;
using System.Collections;

public class SpawnPrefab : MonoBehaviour {
	public GameObject playerPrefab;
	public float delay = 5;
	private float timestamp = 0;
	private bool spawning = false;
	
	void OnNetworkLoadedLevel (){
		timestamp = Time.time;
		spawning = true;

	}
	
	void Update(){
		if(Time.time-timestamp>delay && spawning){
			Network.Instantiate(playerPrefab, transform.position, transform.rotation,0);
			enabled = false;
		}
	}
	
	void OnPlayerDisconnected (NetworkPlayer player) {
		Debug.Log("Server destroying player");
		enabled = false;
		Network.RemoveRPCs(player, 0);
		Network.DestroyPlayerObjects(player);
	}
}
