using UnityEngine;
using System.Collections;

public class SpaceShipNetworkInit : MonoBehaviour {
	
	void OnNetworkInstantiate(NetworkMessageInfo info){
		
		if(networkView.isMine){
			SetEnable(GetComponent<NetworkRigidbody>(), false);
			
		} else {
			name += "(Remote)";
			SetEnable(GetComponent<JetMotor>(), false);
			SetEnable(GetComponent<NewBlasterGun>(), false);
			SetEnable(GetComponent<NetworkRigidbody>(), true);
		}
	}
	
	void SetEnable(MonoBehaviour behaviour, bool enable){
		if(behaviour != null){
			behaviour.enabled = enable;	
		} else {
			Debug.LogError("SpaceShipNetworkInit: Behaviour not found in object "+ name);
		}
	}
}
