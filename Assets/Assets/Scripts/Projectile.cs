using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {
	public int groupID;
	
	void OnDestroy(){
		Debug.Log("Removing: " + groupID);
		if(groupID>999){
			Network.RemoveRPCs(Network.player, groupID);
		}
	}
}
