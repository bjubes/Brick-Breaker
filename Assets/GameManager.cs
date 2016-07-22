using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

	public GameObject leadBall;
	public GameObject dumbBall;
	public GameObject block;
	public GameObject token;

	public Color max, min;
	public Text scoreText, ballCountText;

	public List<GameObject> dumbBallList = new List<GameObject> ();

	int _score;
	public int Score {
		get { 
			return _score;
		}
		set { 
			scoreText.text = "Score: " + value;
			_score = value;
		}
	}

	int _ballCount = 1;
	public int BallCount {
		get { 
			return _ballCount;
		}
		set { 
			ballCountText.text = "Ball Count: " + value;
			_ballCount = value;
			CreateNewBall ();
		}
	}


	Dictionary<int, List<GameObject>> rows = new Dictionary<int, List<GameObject>> ();

	float brickWidth = 0.9375f;
	float leftMostBlockX = -2.34f;
	float brickHeight = 0.375f;

	void Start () {
		SpawnBlockRow ();
	}
	
	void Update () {
		
	}


	void SpawnBlockRow() {
		var spawnedToken = false;
		float screenHeight = Camera.main.orthographicSize;
		float spawnHeight = screenHeight - brickHeight - 0.5f;

		int amountToSpawn = Random.Range (2, 7); //including the token

		var SpawnLocations = new List<float>();

		int i = 0;
		while ( i < amountToSpawn) { //loop until you hit the spawn ammount
			int location = Random.Range(0,6);
			if (!SpawnLocations.Contains (location)) {
				SpawnLocations.Add (location);
				i+=1;
			}
		}

		rows.Add (Score, new List<GameObject>());
		foreach (float loc in SpawnLocations) {

		

			var xVal = (loc * brickWidth) + leftMostBlockX;
		

			Vector2 pos = new Vector2 (xVal, spawnHeight);
			if (!spawnedToken) {
				pos.y -= 0.18f; //offset since coins are smaller
				GameObject newToken = (GameObject)Instantiate (token, pos, Quaternion.identity);
				rows [Score].Add (newToken);
				spawnedToken = true;
			} else {
				var newBlock = (GameObject)Instantiate (block, pos, Quaternion.identity);
				newBlock.GetComponent<Brick> ().Health = Score;
				rows [Score].Add (newBlock);
			}
		}
	}

	public void TurnEnded() {
		
		Score += 1;
	
		foreach (int sc in rows.Keys) {
			foreach (GameObject go in rows[sc]) {
				if (go == null) {
					continue;
				}
				go.transform.Translate (new Vector2 (0, -brickHeight));
			}
		}

		SpawnBlockRow ();
	}

	void CreateNewBall() {

		var ball = (GameObject)Instantiate (dumbBall, Vector2.zero, Quaternion.identity);
		ball.SetActive (false);
		dumbBallList.Add (ball);
		print("balls: " + dumbBallList.Count);

	}

}
