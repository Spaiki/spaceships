using UnityEngine;
using System.Collections;

public class NetworkObject : MonoBehaviour {
	private NetworkManagerScript manager;
	public bool remote = false;
	
	
	void Awake(){
		manager = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<NetworkManagerScript>();
		
	}
	
	void Start(){
		if(!remote){
			networkView.viewID = Network.AllocateViewID();
			manager.CreateObject(gameObject, networkView.viewID, transform.position, transform.rotation);
		}
	}

//	public GameObject CreateObject(GameObject o, Transform t){
//		var id = Network.AllocateViewID();
//		var clone = Instantiate(o, t.position, t.rotation) as GameObject;
//		clone.GetComponent<NetworkView>().viewID = id;
//		networkView.RPC("SpawnProjectile",RPCMode.Others,id,spawnPoint.position);
//	}
	
//	[RPC]
//	void SpawnProjectile(NetworkViewID id, Vector3 position){
//		var clone = Instantiate(gameObject, position, Quaternion.identity) as GameObject;
//		clone.GetComponent<NetworkView>().viewID = id;
//	}
	
//	[RPC]
//	void NetworkInstantiate(NetworkViewID id, Vector3 position, Quaternion rotation){
//		var clone = Instantiate(gameObject, position, rotation) as GameObject;
//		Debug.Log ("RemoteInstantiating: " + clone.name + " viewID: " + id);
//		var view = clone.GetComponent<NetworkView>();
//		view.viewID = id;
//		clone.name += " (Remote)";
//	}
}
