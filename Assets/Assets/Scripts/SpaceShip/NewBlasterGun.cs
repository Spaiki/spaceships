using UnityEngine;
using System.Collections;

public class NewBlasterGun : MonoBehaviour {
	private NetworkManager manager;
	private float fire_timer = 0;
	private bool fire_pressed = false;
	
	public Transform spawnPoint;
	public GameObject projectile;
	
	public float force = 20;
	public float fire_rate = 5;
	
	void Awake(){
		manager = GameObject.FindGameObjectWithTag("NetworkManager").GetComponent<NetworkManager>();
	}
	
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
			var groupID = manager.AllocateID();
			var clone = (GameObject) Network.Instantiate(projectile,spawnPoint.position,spawnPoint.rotation, groupID);
			clone.GetComponent<Projectile>().groupID = groupID;
			Debug.Log("Group: " + clone.networkView.group);
				
			clone.rigidbody.velocity = rigidbody.velocity;
			clone.rigidbody.AddForce(spawnPoint.forward*force);
			fire_timer = 1/fire_rate;
			fire_pressed = false;
		}
	}
}
