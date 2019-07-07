using UnityEngine;
using System.Collections;

public class BackGroundController : MonoBehaviour {
	
	public Renderer Background;
	public float speedBG;
	public Renderer Midground;
	public float speedMG;
	public Renderer Forceground;
	public float speedFG;

	Camera target;
	float startPosX;

	// Use this for initialization
	void Start () {
		target = Camera.main;
		startPosX = target.transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
		var x = target.transform.position.x - startPosX;

		if (Background != null)
			Background.material.mainTextureOffset =  new Vector2 (x * speedBG, Background.material.mainTextureOffset.y);
		
		if (Midground != null)
			Midground.material.mainTextureOffset =  new Vector2 (x * speedMG, Midground.material.mainTextureOffset.y);
		
		if (Forceground != null)
			Forceground.material.mainTextureOffset =  new Vector2 (x * speedFG, Forceground.material.mainTextureOffset.y);
	}
}
