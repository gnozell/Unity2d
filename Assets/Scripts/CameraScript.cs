using UnityEngine;
using System.Collections;

public class CameraScript : MonoBehaviour {

	public Transform target;
	public float dampTime = 0.15f;
	public float lowerLimit = -4f;


	private string phase = "followPlayer";
	private Camera thiscam;
	private Vector3 velocity = Vector3.zero;

	// Use this for initialization
	void Start () {
		thiscam = GetComponent<Camera> ();
	}
	
	// Update is called once per frame
	void Update () {
		switch (phase) {

		case "followPlayer":{
				if (target)
				{
					Vector3 point = thiscam.WorldToViewportPoint(target.position);
					Vector3 delta = target.position - thiscam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 20));
					Vector3 destination = transform.position + delta;

					if (destination.y < lowerLimit) {
						destination.y = lowerLimit;
					}

					// moves the camera
					transform.position = Vector3.SmoothDamp(transform.position, destination, ref velocity, dampTime);
				}
				break;
			}

		case "freeze":
			{
				
				break;
			}

		default:
			{
				phase = "followPlayer";
				break;
			}
		}
	
	}
}
