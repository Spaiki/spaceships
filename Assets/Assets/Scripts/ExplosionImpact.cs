using UnityEngine;
using System.Collections;

public class ExplosionImpact : MonoBehaviour {
	private Detonator detonator;
	
	void Awake () {
		detonator = GetComponent<Detonator>();
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other) {
		Debug.Log("Collision!");
		detonator.Explode();
		//Network.Destroy(gameObject);
	}
}
