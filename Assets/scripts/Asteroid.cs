using UnityEngine;
using System.Collections;

public class Asteroid : MonoBehaviour {

	public float minTorgue = -10f;
	public float maxTorque = 20f;

	public float minForce = 1f;
	public float maxForce = 5f;

	public GameObject nextAsteroid;
    public GameObject explosionBig, explosionMedium, explosionSmall;
	
	void Start () 
	{
		float magnitude = Random.Range(minForce, maxForce);
		float torque = Random.Range(minTorgue, maxTorque);

		float x = Random.Range(-1f, 1f);
		float y = Random.Range(-1f, 1f);

		GetComponent<Rigidbody2D>().AddForce(magnitude * 1000 * new Vector2(x ,y));
		GetComponent<Rigidbody2D>().AddTorque(torque);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "playerBullet")
		{

			Logic.instance.DestroyAsteroid();
			if (gameObject.tag == "asteroidBig")
			{
				Logic.instance.AddScore(50);
                Instantiate(explosionBig, transform.position, new Quaternion());
			}
			if (gameObject.tag == "asteroidMedium")
			{
				Logic.instance.AddScore(25);
                Instantiate(explosionMedium, transform.position, new Quaternion());
			}
			if (gameObject.tag == "asteroidSmall")
			{
				Logic.instance.AddScore(10);
                Instantiate(explosionSmall, transform.position, new Quaternion());
			}
			

			Destroy(gameObject);

			if (nextAsteroid != null)
			{
				Instantiate(nextAsteroid, new Vector3(transform.position.x + 100, transform.position.y - 100, transform.position.z),                                                                       transform.rotation);
				Logic.instance.addAsteroid();

				Instantiate(nextAsteroid, new Vector3(transform.position.x - 100, transform.position.y + 100, transform.position.z),                                                                        transform.rotation); 
				Logic.instance.addAsteroid();
			}
			Destroy(col.gameObject);
		}
		
	}
}
