using UnityEngine;
using System.Collections;

public class enemy_manager : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public Transform player;

	private float spawnTime;
	public float minSpawnTime = 5.0f;
	public float maxSpawnTime = 15.0f;
	private float lastSpawnTime;

	// Use this for initialization
	void Start () {
		SpawnNewEnemy ();
	}
	
	// Update is called once per frame
	void Update () {
	if (lastSpawnTime + spawnTime < Time.time) 
		{
			SpawnNewEnemy();
		}

    }

	void SpawnNewEnemy ()
	{
		int los = Random.Range (0, 3);
		Vector3 pos = new Vector3 (0, 0, 0);
		if (los == 0) {
			pos = new Vector3(-2, 15, 0);
		} else if (los == 1) {
			pos = new Vector3 (0, 15, 0);
		} else if (los == 2) {
			pos = new Vector3 (2, 15, 0);
		}
		pos += new Vector3 (0, 8, 0);
		lastSpawnTime = Time.time;
		spawnTime = Random.Range (minSpawnTime, maxSpawnTime);

        los = Random.Range(0, 3);
        GameObject newEnemy;

        if (los == 0)
        {
            newEnemy = Instantiate (enemyPrefab, pos, Quaternion.identity) as GameObject; 
		    newEnemy.transform.Rotate(new Vector3 (0, 0, 0));
        }
        else if (los == 1)
        {
            newEnemy = Instantiate (enemyPrefab2, pos, Quaternion.identity) as GameObject;
            newEnemy.transform.Rotate(new Vector3 (0, 0, 0));
        }
        else if (los == 2)
        {
            newEnemy = Instantiate(enemyPrefab3, pos, Quaternion.identity) as GameObject;
            newEnemy.transform.Rotate(new Vector3(0, 0, 90));
        }



    }
}
