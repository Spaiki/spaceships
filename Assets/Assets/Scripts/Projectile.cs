using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

	void Start () {

	}
	

	void Update () {

	}
	
	[RPC]
	void SpawnProjectileRPC(NetworkViewID id){
		var clone = (GameObject)Instantiate(gameObject);
		clone.GetComponent<NetworkView>().viewID = id;
	}
}
