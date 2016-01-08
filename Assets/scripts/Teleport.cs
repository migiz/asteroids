using UnityEngine;
using System.Collections;

public class Teleport : MonoBehaviour {

	public float minX = -3600f;
	public float minY = -2100f;
	public float maxX = 3600f;
	public float maxY = 2100f;

	
	void FixedUpdate () 
	{
		float x = transform.position.x;
		float y = transform.position.y;

		if (x < minX) x = maxX;
		else if (x > maxX) x = minX;

		if (y < minY) y = maxY;
		else if (y > maxY) y = minY;

		transform.position = new Vector3(x, y, transform.position.z);
	}
}
