using UnityEngine;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

public class NetworkManagerScript : MonoBehaviour {
	
	public void CreateObject(GameObject obj, NetworkViewID id, Vector3 position, Quaternion rotation){
		var objName = obj.name.Substring(0,obj.name.IndexOf('('));
		Debug.Log("Creating object: " + objName);
		networkView.RPC(
			"CreateObjectRPC", 
			RPCMode.Others, 
			id,
			objName,
			position, 
			rotation);
	}
	
	[RPC]
	void CreateObjectRPC(NetworkViewID id, string objName, Vector3 position, Quaternion rotation){
		
		var clone = (GameObject) Instantiate(Resources.Load(objName), position, rotation);
		clone.GetComponent<NetworkObject>().remote = true;
		clone.networkView.viewID = id;
	}
}
