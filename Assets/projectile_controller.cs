using UnityEngine;
using System.Collections;

public class projectile_controller : MonoBehaviour {

	public int speed = 3000;
	float startTime;
	public float lifeTime = 3.0f;
	public ParticleSystem explosion;

	void Start () {
		GetComponent<Rigidbody> ().AddForce (Vector3.up * speed);
		//Destroy (gameObject, 3.0f); //prosta metoda
		startTime = Time.time;
	}
	
	void Update ()
	{
		if (startTime + lifeTime < Time.time) {
			Destroy(gameObject);
		}
	}

	void OnTriggerEnter(Collider col)
	{
		
		if (col.tag == "enemy") 
		{
			Instantiate(explosion,col.transform.position, Quaternion.identity);
			Destroy (col.gameObject);
			GameObject.FindObjectOfType<game_manager>().AddScore();
			Destroy (gameObject);


		}
		
	}

}
