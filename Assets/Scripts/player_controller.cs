using UnityEngine;
using System.Collections;

public class player_controller : MonoBehaviour {

	public float speed = 10.0f;
	public GameObject projectilePrefab;
    public Rigidbody rb;
	public AudioClip weapon1;
	public AudioClip bum;


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


    // Update is called once per frame
    void Update () {


        if (Input.GetKeyDown(KeyCode.UpArrow)||Input.GetMouseButtonUp(1)) 
		{
            MoveLeft();

        }
	else if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetMouseButtonUp(0)) 
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

    }

    void OnTriggerEnter(Collider col)
	{
		if (col.tag == "enemy") {
			GameObject.FindObjectOfType<game_manager>().Lifes();
			Destroy (col.gameObject);
			GetComponent<AudioSource>().clip = bum;
			GetComponent<AudioSource>().Play();
            GetComponent<VoiceRecognition>().ChooseNewLeftWord(true);
            GetComponent<VoiceRecognition>().ChooseNewRightWord(true);
        }
        if (col.tag == "ball")
        {
            GameObject.FindObjectOfType<game_manager>().PlusPlus();
            Destroy(col.gameObject);
            
        }
    }


}
