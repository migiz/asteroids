using UnityEngine;
using System.Collections;

public class EnemyBulletBehaviour : MonoBehaviour
{

    public int bulletSpeed = 1000;
    Renderer[] renderers;
    public float lifeTime = 3f;
    private float time;
    private GameObject playerShip;

    void Start()
    {
        time = lifeTime;
        playerShip = UnityEngine.GameObject.FindGameObjectWithTag("playerShip");
        float angle = Mathf.Atan2(playerShip.transform.position.y - transform.position.y,
                                     playerShip.transform.position.x - transform.position.x) * Mathf.Rad2Deg;
        renderers = GetComponentsInChildren<Renderer>();
        //GetComponent<Rigidbody2D>().AddForce(new Vector3(0,-1,transform.position.z) * bulletSpeed);
        GetComponent<Rigidbody2D>().AddForce(transform.up * bulletSpeed);
        Debug.Log(transform.up);
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
