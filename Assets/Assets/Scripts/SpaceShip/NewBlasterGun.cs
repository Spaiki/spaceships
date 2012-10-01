using UnityEngine;
using System.Collections;

public class NewBlasterGun : MonoBehaviour {
	private float fire_timer = 0;
	private bool fire_pressed = false;
	
	public Transform spawnPoint;
	public GameObject projectile;
	
	public float force = 20;
	public float fire_rate = 5;
	
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if(rigidbody==null || projectile==null)
			return;

		if(!fire_pressed && Input.GetButtonDown("Fire1")){
			fire_pressed = true;	
		}

		if(fire_timer>0){
			fire_timer -= Time.deltaTime;
		} else {
			Fire();
		}
	}
	
	void Fire() {
		if(fire_pressed){
			var clone = (GameObject) Instantiate(projectile,spawnPoint.position,spawnPoint.rotation);
			clone.rigidbody.velocity = rigidbody.velocity;
			clone.rigidbody.AddForce(spawnPoint.forward*force);
			fire_timer = 1/fire_rate;
			fire_pressed = false;
		}
	}
	
//	void Fire() {
//		if(fire_pressed){
//			var id = Network.AllocateViewID();
//			var clone = Instantiate(projectile, spawnPoint.position, Quaternion.identity) as GameObject;
//			clone.GetComponent<NetworkView>().viewID = id;
//			networkView.RPC("SpawnProjectile",RPCMode.Others,id,spawnPoint.position);
//			clone.rigidbody.velocity = rigidbody.velocity;
//			clone.rigidbody.AddForce(spawnPoint.forward*force);
//			fire_timer = 1/fire_rate;
//			fire_pressed = false;
//		}
//	}
	
//	void Fire() {
//		if(fire_pressed){
//			var id = Network.AllocateViewID();
//			var clone = projectile.GetComponent<NetworkObject>().CreateObject(projectile, spawnPoint);
//			clone.rigidbody.velocity = rigidbody.velocity;
//			clone.rigidbody.AddForce(spawnPoint.forward*force);
//			fire_timer = 1/fire_rate;
//			fire_pressed = false;
//		}
//	}
	
	[RPC]
	void SpawnProjectile(NetworkViewID id, Vector3 position){
		var clone = Instantiate(projectile, position, Quaternion.identity) as GameObject;
		clone.GetComponent<NetworkView>().viewID = id;
	}
}
