using UnityEngine;
using System.Collections;

public class Brick : MonoBehaviour {

	public int Health = 1;
    new public Color light;
    public Color dark;

	GameManager gm;
    SpriteRenderer sr;

	void Start () {
		gm = GameObject.FindObjectOfType<GameManager> ();
        sr = transform.GetChild(0).GetComponent<SpriteRenderer>();
        gm.TurnEnd += OnTurnEnd;    
	}
	
	// Update is called once per frame
	void Update () {
		if (Health <= 0) {
			Kill();
		}
	}

	void OnCollisionEnter2D(Collision2D col) {

		if (col.gameObject.tag == "Ball" ) {
			//collided with a ball
			Health -= 1;
			CalculateColor ();
		}

	}

    void OnTurnEnd(int score)
    {
        CalculateColor(score);
    }

	void CalculateColor(int score = 0) {
        if (score == 0)
        {
            score = gm.Score;
        }
        if (sr == null)
        {
            //the brick was destroyed this round, so sr doesnt exist
            return;
        }
        sr.color = Color.Lerp(light, dark, (float)Health / score);
	}

	void Kill() {
		//break anim
		Destroy(this.gameObject);
	}
}
