using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {

	public float speed = 10.0f;
	public GameObject projectilePrefab;
    public Rigidbody rb;
	public AudioClip weapon1;
	public AudioClip bum;

#if UNITY_ANDROID
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    public void MoveLeft()
    {
        if (this.transform.position.x != -2)
        {
            this.transform.position = new Vector3(this.transform.position.x - 2, this.transform.position.y, this.transform.position.z);
        }
    }
    public void MoveRight()
    {
        if (this.transform.position.x != 2)
        {
            this.transform.position = new Vector3(this.transform.position.x + 2, this.transform.position.y, this.transform.position.z);
        }
    }
#endif

    // Update is called once per frame
    void Update () {

#if UNITY_EDITOR || UNITY_STANDALONE

        if (Input.GetKeyDown(KeyCode.LeftArrow)) 
		{
            MoveLeft();

        }
	else if (Input.GetKeyDown(KeyCode.RightArrow)) 
		{
            MoveRight();
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
