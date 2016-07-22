using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int Health = 1;

	GameManager gm;
	void Start () {
		gm = GameObject.FindObjectOfType<GameManager> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Health <= 0) {
			Kill ();
		}
	}

	void OnCollisionEnter2D(Collision2D col) {

		if (col.gameObject.tag == "Ball" ) {
			//collided with a ball
			Health -= 1;
			CalculateColor ();

		}

	}

	void CalculateColor() {


	}

	void Kill() {
		//break anim
		Destroy(this.gameObject);
	}
}
