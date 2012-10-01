using UnityEngine;
using System.Collections;

public class BlasterGun : MonoBehaviour {
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
			SpawnProjectile(spawnPoint, rigidbody.velocity, spawnPoint.forward * force);
			fire_timer = 1/fire_rate;
			fire_pressed = false;
		}
	}
	
	void SpawnProjectile(Transform spawnPoint, Vector3 velocity, Vector3 force){
		
		if(Network.peerType == NetworkPeerType.Disconnected){
			Debug.Log("Creating view: " + networkView.viewID);
			var clone = ((GameObject)Instantiate(projectile, spawnPoint.position, spawnPoint.rotation)).rigidbody;
			clone.velocity = velocity;
			clone.AddForce(force);
			
		} else  {
			var clone = (GameObject)Network.Instantiate(projectile, spawnPoint.position, spawnPoint.rotation,0);
			clone.rigidbody.velocity = velocity;
			clone.rigidbody.AddForce(force);
		} 
	}
	
//	void SpawnProjectile(Transform spawnPoint, Vector3 velocity, Vector3 force){
//		
//		if(Network.peerType == NetworkPeerType.Disconnected){
//			Debug.Log("Creating view: " + networkView.viewID);
//			var clone = ((GameObject)Instantiate(projectile, spawnPoint.position, spawnPoint.rotation)).rigidbody;
//			clone.velocity = velocity;
//			clone.AddForce(force);
//		} else  {
//			var id = Network.AllocateViewID();
//			var clone = (GameObject)Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);
//			clone.rigidbody.velocity = velocity;
//			clone.rigidbody.AddForce(force);
//			clone.networkView.viewID = id;
//			clone.networkView.RPC("SpawnProjectileRPC", RPCMode.OthersBuffered, id);
//			Debug.Log("Creating view: " + clone.networkView.viewID);
//		} 
//	}
}
