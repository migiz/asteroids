using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

	public float shotInterval = 1f;
	public GameObject enemyBulletPrefab;
	public GameObject cannon;
	private GameObject playerShip;

	private float interval;

	// Use this for initialization
	void Start () {

		interval = shotInterval;
		
	
	}
	
	// Update is called once per frame
	void Update () {

		interval -= Time.deltaTime;
		playerShip = UnityEngine.GameObject.FindGameObjectWithTag("playerShip");
		if (playerShip != null)
		{
			transform.rotation = Quaternion.LookRotation(Vector3.forward, playerShip.transform.position - transform.position);

		}
		if (interval < 0)
		{
			Shoot();
			interval = shotInterval;
		}

	}

	void Shoot()
	{
		playerShip = UnityEngine.GameObject.FindGameObjectWithTag("playerShip");
		//Debug.Log(playerShip.transform.position);

	   /* var targetRotation = Quaternion.LookRotation(playerShip.transform.position - transform.position);
		float aux = 0.5f;
		var str = Mathf.Min(aux * Time.deltaTime, 1);*/

		//transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, str);
		if (playerShip != null)
		{
			float angle = (Mathf.Atan2(playerShip.transform.position.y - transform.position.y,
									 playerShip.transform.position.x - transform.position.x) - Mathf.PI / 2) * Mathf.Rad2Deg;
			Instantiate(enemyBulletPrefab, cannon.transform.position, Quaternion.Euler(new Vector3(0f,0f,angle)));
														   //laske pelaajan sijainti
		}
	}

}
