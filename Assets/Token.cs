using UnityEngine;
using System.Collections;

public class Token : MonoBehaviour {

	GameManager gm;

	void Start () {
		gm = GameObject.FindObjectOfType<GameManager> ();

	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D col) {

		if (col.gameObject.tag == "Ball" ) {
			//collided with a ball
			gm.BallCount += 1;
			Destroy (this.gameObject);


		}

	}}
