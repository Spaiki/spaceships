using UnityEngine;
using System.Collections;

public class ShipMotor : MonoBehaviour {
	public Rigidbody ship;
	public float torque = 20;
	public float force = 20;

	// Use this for initialization
	void Start () {
		if(networkView.isMine){
			var camera = GameObject.FindWithTag("MainCamera");
			var orbit = camera.GetComponent<SmoothFollow>();
			orbit.target = ship.transform;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if(networkView.isMine){
			var t = ship.transform;
			var steer = Input.GetAxis("Horizontal")*torque;
			var acc = Input.GetAxis("Vertical")*force;
			
			//ship.angularVelocity += t.up * steer;
			//ship.velocity += acc * t.forward;
			
			ship.AddForce(t.forward*(acc));
			ship.AddTorque(t.up*steer);
			//ship.AddForce(Quaternion.AngleAxis(steer*100,t.up) * t.forward * (acc*100));	
		}
	}
}
