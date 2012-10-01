using UnityEngine;
using System.Collections;

public class TimeoutDestructor : MonoBehaviour {
	public float timeout = 5;
	private float initTime = 0;
	
	// Use this for initialization
	void Awake () {
		if(networkView.isMine){
			initTime = Time.time;
		} else {
			enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(Time.time-initTime>timeout){
			Network.Destroy(gameObject);
		}
	}
}
