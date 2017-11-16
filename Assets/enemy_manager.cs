using UnityEngine;
using System.Collections;

public class enemy_manager : MonoBehaviour {

	public GameObject enemyPrefab;
	public GameObject enemyPrefab2;
    public GameObject enemyPrefab3;
    public Transform player;

	private float spawnTime;
	public float minSpawnTime = 1.0f;
	public float maxSpawnTime = 3.0f;
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
		Vector3 pos = new Vector3(Random.Range(-4,4),15,0);
		pos += new Vector3 (0, 8, 0);
		lastSpawnTime = Time.time;
		spawnTime = Random.Range (minSpawnTime, maxSpawnTime);

		GameObject newEnemy;
		GameObject newEnemy2;
        GameObject newEnemy3;

        newEnemy = Instantiate (enemyPrefab, pos, Quaternion.identity) as GameObject; 
		newEnemy.transform.Rotate(new Vector3 (90, 180, 0));
		
		newEnemy2 = Instantiate (enemyPrefab2, pos, Quaternion.identity) as GameObject; 
		newEnemy2.transform.Rotate(new Vector3 (90, 180, 0));

        newEnemy3 = Instantiate(enemyPrefab3, pos, Quaternion.identity) as GameObject;
        newEnemy3.transform.Rotate(new Vector3(0, 0, 0));
    }
}
