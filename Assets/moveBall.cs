using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class moveBall : MonoBehaviour {

	public float speed = 8f;
	bool clicked = false;

	bool moving = false;

	Rigidbody2D rb;
	GameManager gm;


	//for coroutine
	List<GameObject> balls;
	Vector3 origPos;
	Vector2 vel;



	void Start () {
		gm = GameObject.FindObjectOfType<GameManager> ();
		rb = this.GetComponent<Rigidbody2D> ();
		if (rb == null) {
			Debug.Log ("no rigid body");
		}
	}
	
	// Update is called once per frame
	void Update () {
		clicked = Input.GetMouseButtonDown(0);

		if (transform.position.y <= (-4.9 + 1/8)) {
			moving = false;
			rb.velocity = Vector2.zero;
			transform.position = new Vector2 (transform.position.x, (-4.9f + 1.0f/8.0f));
			gm.TurnEnded ();
		}
			
	}

	void FixedUpdate() {
		
		if (moving) {		
			rb.velocity = rb.velocity.normalized * speed;
		}
	}

	public void MoveBall(Vector2 dir) {
		if (moving) {
			return;
		}

		rb.velocity = dir.normalized * speed;
		moving = true;

		balls = gm.dumbBallList;
		origPos = transform.position;
		vel = rb.velocity;

		StartCoroutine("SpawnBalls");

	}

	IEnumerator SpawnBalls() {
		foreach (GameObject ball in balls) {
			ball.transform.position = origPos;
			ball.SetActive (true);
			ball.GetComponent<Rigidbody2D> ().velocity = vel;
			print ("ball made");
			yield return new WaitForSeconds (0.1f);
		}
	}

}
