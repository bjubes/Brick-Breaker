using UnityEngine;
using System.Collections;

public class DumbBall : MonoBehaviour {

	public float speed = 8f;
	bool clicked = false;

	bool moving = false;

	Rigidbody2D rb;
	GameManager gm;

	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
		if (rb == null) {
			Debug.Log ("no rigid body");
		}
	}

	// Update is called once per frame
	void Update () {

		if (transform.position.y <= (-4.9 + 1/8)) {	
			gameObject.SetActive (false);
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
	}

}
