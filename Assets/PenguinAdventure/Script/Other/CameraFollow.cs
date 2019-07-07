using UnityEngine;
using System.Collections;
/// <summary>
/// Camera follow the player
/// </summary>
public class CameraFollow : MonoBehaviour {
	[Tooltip("the X distance of the Player and Camera")]
	public float offsetX = 3f;
	[Tooltip("How smooth the camera follow the player, lower is better")]
	public float smooth = 0.1f;
	[Tooltip("Limited positon up")]
	public float limitedUp = 2f;
	[Tooltip("Limited positon down")]
	public float limitedDown = 0f;
	[Tooltip("Limited positon left")]
	public float limitedLeft = 0f;
	[Tooltip("Limited positon right")]
	public float limitedRight = 100f;

	private Transform player;
	private float playerX;
	private float playerY;
	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ().transform;		//find the player on scene
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		playerX = Mathf.Clamp (player.position.x  + offsetX, limitedLeft, limitedRight);
		playerY= Mathf.Clamp (player.position.y, limitedDown, limitedUp);
		//follow the player
		transform.position = Vector3.Lerp (transform.position, new Vector3 (playerX, playerY, transform.position.z), smooth);

	}
}
