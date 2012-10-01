using UnityEngine;
using System.Collections;

public class JetMotor : MonoBehaviour {
	public float torque = 20;
	public float force = 20;
	
//	private float[,] force_map = new float[1,1];
//	private float[,] torque_map = new float[1,1];
	
	public string throttle_key = "Vertical";
	public string steer_key = "Horizontal";

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(transform == null || rigidbody == null)
			return;

		var steer = Input.GetAxis(steer_key)*torque;
		var acc = Input.GetAxis(throttle_key)*force;

		rigidbody.AddForce(transform.forward*(acc));
		rigidbody.AddTorque(transform.up*steer);
	}
}
