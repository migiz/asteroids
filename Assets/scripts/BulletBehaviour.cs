using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

	public int bulletSpeed = 1000;
	Renderer[] renderers;
	public float lifeTime = 3f;
	private float time;

	void Start () 
	{
		time = lifeTime;
		renderers = GetComponentsInChildren<Renderer>();
		GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
	}

	void Update()
	{
		time -= Time.deltaTime;
		if (time < 0)
		{
			Destroy(gameObject);
		}
		foreach (var renderer in renderers)
		{
			if (!renderer.isVisible)
			{
				Destroy(gameObject);
			}
		}
	}
	
}
