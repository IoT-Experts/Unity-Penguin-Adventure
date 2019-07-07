using UnityEngine;
using System.Collections;

public class RotateAround : MonoBehaviour {
	public float speed = 0.5f;
	
	// Update is called once per frame
	void Update () {
		transform.Rotate (Vector3.forward, speed);
	}
}
