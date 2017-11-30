using UnityEngine;
using System.Collections;

public class enemy_ship : MonoBehaviour {
	//public float speed = 100;
	public float minSpeed = 60f;
	public float maxSpeed = 70f;
	// Use this for initialization
	void Start () {
		GetComponent<Rigidbody> ().AddForce (-Vector3.up * RandomSpeed());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	float RandomSpeed()
	{
		float val = Random.Range (minSpeed, maxSpeed);
		return val;
	}
}
