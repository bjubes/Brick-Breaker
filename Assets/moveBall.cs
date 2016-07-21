using UnityEngine;
using System.Collections;

public class moveBall : MonoBehaviour {

	float speed = 3f;
	bool clicked = false;

	Rigidbody2D rb;

	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		if (rb == null) {
			Debug.Log ("no rigid body");
		}
	}
	
	// Update is called once per frame
	void Update () {
		clicked = Input.GetMouseButtonDown(0);
	}

	void FixedUpdate() {
		if (clicked) {
			rb.velocity = Vector2.up * speed;
		}

		rb.velocity = rb.velocity.normalized * speed;
	}
}
