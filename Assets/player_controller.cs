using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {

	public float speed = 10.0f;
	private Rigidbody rb;
	public GameObject projectilePrefab;
	public AudioClip weapon1;
	public AudioClip bum;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();	
	}
	
	// Update is called once per frame
	void Update () {

#if UNITY_EDITOR || UNITY_STANDALONE

        if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			rb.AddForce(-transform.right*speed);
		}
	else if (Input.GetKey (KeyCode.RightArrow)) 
		{
			rb.AddForce(transform.right*speed);
		}
	 if (Input.GetKeyUp (KeyCode.LeftArrow) || Input.GetKeyUp (KeyCode.RightArrow)) 
		{
			rb.velocity = new Vector3 (0,0,0);

		}
	if (Input.GetKeyDown(KeyCode.Space))
		{

			Vector3 pos = transform.position;
			pos+= new Vector3(0, 1.5f,0);

			GameObject newProjectile;
			newProjectile = Instantiate(projectilePrefab, pos, Quaternion.identity) as GameObject;
			newProjectile.transform.Rotate(new Vector3 (-90, 0, 0));
			
			


			GetComponent<AudioSource>().clip = weapon1; //dla kilku broni
			GetComponent<AudioSource>().Play();


		}

#endif

#if UNITY_ANDROID

    if (Input.acceleration.x > 0)
        {
            rb.AddForce(transform.right * speed);
        }

    else if (Input.acceleration.x < 0)
        {
            rb.AddForce(-transform.right * speed);
        }
    if (Input.touchCount > 0)
        {
            Vector3 pos = transform.position;
            pos += new Vector3(0, 1.5f, 0);

            GameObject newProjectile;
            newProjectile = Instantiate(projectilePrefab, pos, Quaternion.identity) as GameObject;
            newProjectile.transform.Rotate(new Vector3(-90, 0, 0));




            GetComponent<AudioSource>().clip = weapon1; //dla kilku broni
            GetComponent<AudioSource>().Play();
        }

#endif





    }

    void OnTriggerEnter(Collider col)
	{
		if (col.tag == "enemy") {
			GameObject.FindObjectOfType<game_manager>().Lifes();
			Destroy (col.gameObject);
			GetComponent<AudioSource>().clip = bum;
			GetComponent<AudioSource>().Play();
		}
        if (col.tag == "ball")
        {
            GameObject.FindObjectOfType<game_manager>().PlusPlus();
            Destroy(col.gameObject);
            
        }
    }


}
