using UnityEngine;
using System.Collections;

public class DragScript : MonoBehaviour {

	public moveBall ball;

	Vector2 downPos;
	Vector2 upPos;
	bool hasClickedDown = false;

	LineRenderer lr;
	// Use this for initialization
	void Start () {
		lr = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			hasClickedDown = true;
			downPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		}

		if (Input.GetMouseButtonUp(0)) {
			
			upPos = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			Vector2 dir = upPos - downPos;
			ball.MoveBall (dir.normalized);
			hasClickedDown = false;
			lr.enabled = false;
		}


		//line
		if (hasClickedDown) {
			lr.enabled = true;
			lr.SetPosition (0, downPos);
			lr.SetPosition (0, Camera.main.ScreenToWorldPoint (Input.mousePosition));
		}

	}
}
