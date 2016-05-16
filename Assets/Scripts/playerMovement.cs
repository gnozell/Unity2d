using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	Rigidbody playerRb;
	private float speed = 10f;
	public float cSpeed;
	public bool facingRight = true;

	// Use this for initialization
	void Start () {
		playerRb = GetComponent<Rigidbody> ();
		cSpeed = speed;
	}
	
	// Update is called once per frame
	void Update () {
		float hor = Input.GetAxis ("Horizontal");
		float vert = Input.GetAxis ("Vertical");

		playerRb.AddForce (new Vector3 (hor * cSpeed,0, vert * cSpeed));

		// limits max speed
		if (playerRb.velocity.magnitude > speed) {
			playerRb.velocity = Vector3.ClampMagnitude(playerRb.velocity, cSpeed);
		}

		// turning the sprite bool
		if (hor > 0) {
			facingRight = true;
		} else if (hor < 0) {
			facingRight = false;
		}

		// action of turning
		if (facingRight){
			if (transform.rotation.eulerAngles.y > 0) {
				// turns to 0
				transform.Rotate(new Vector3(0,-5,0));
			}
		}else{
			if (transform.rotation.eulerAngles.y < 180) {
				// turns to 180
				transform.Rotate(new Vector3(0,5,0));
			}
		}

		// Jumping
		if (Input.GetButtonDown ("Jump")) {
			playerRb.AddForce (new Vector3 (0,cSpeed*100, 0));
		}
	
	}
}
