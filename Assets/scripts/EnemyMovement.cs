using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float minForce = 150f;
	public float maxForce = 500f;

	

	public float turnInterval = 1f;
    public GameObject explosionEnemy;

	private float directionChangeInterval;

	// Use this for initialization
	void Start () {

		directionChangeInterval = turnInterval;

		Move();
	
	}
	
	// Update is called once per frame
	void Update () {
		directionChangeInterval -= Time.deltaTime;
		if (directionChangeInterval < 0)
		{
			Move();
			directionChangeInterval = turnInterval;
		}
	}

	void Move()
	{
		float force = Random.Range(minForce, maxForce);
		float x = Random.Range(-1f, 1f);
		float y = Random.Range(-1f, 1f);

		GetComponent<Rigidbody2D>().AddForce((force * 100) * new Vector2(x,y));
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "playerBullet")
		{
				Destroy(gameObject);
				Logic.instance.AddScore(100);
                Instantiate(explosionEnemy, transform.position, new Quaternion());
		}
	}
}
