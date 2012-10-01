using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(networkView.isMine){
			var camera = GameObject.FindWithTag("MainCamera");
			var smooth = camera.GetComponent<SmoothFollow>();
			smooth.target = transform;
			enabled = false;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
