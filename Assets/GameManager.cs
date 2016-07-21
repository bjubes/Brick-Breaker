using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public GameObject ball;
	public GameObject block;

	int score;

	float leftMostBlockX = -2.3f;
	float blockHeight = 0.4f;

	void Start () {
		SpawnBlockRow ();
	}
	
	void Update () {
		
	}


	void SpawnBlockRow() {
		float screenHeight = Camera.main.orthographicSize;
		float spawnHeight = screenHeight - blockHeight;

		int amountToSpawn = Random.Range (1, 6);
		Debug.Log (amountToSpawn);

		var SpawnLocations = new List<float>();

		int i = 0;
		while ( i < amountToSpawn) { //loop until you hit the spawn ammount
			int location = Random.Range(0,5); //TODO: make it spawn 6 and make six fit perfectly in the screen
			if (!SpawnLocations.Contains (location)) {
				SpawnLocations.Add (location);
				i+=1;
			}
		}
		foreach (float loc in SpawnLocations){
			var xVal = loc + leftMostBlockX;
		

			Vector2 pos = new Vector2 (xVal, spawnHeight);
			var Block = (GameObject)Instantiate(block, pos, Quaternion.identity);
		}
	}

}
