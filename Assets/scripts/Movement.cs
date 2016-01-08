using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public int rotateSpeed = 360;
    public int thrustSpeed = 500;
    public ParticleSystem thrustEffect;
    public GameObject explosionPlayer;

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Vector3 newRotation = transform.rotation.eulerAngles;
            newRotation.z += 10;
            transform.rotation = Quaternion.Euler(newRotation);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Vector3 newRotation = transform.rotation.eulerAngles;
            newRotation.z -= 10;
            transform.rotation = Quaternion.Euler(newRotation);
        }
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<Rigidbody2D>().AddForce(transform.up * thrustSpeed * 3);
            thrustEffect.Play();

        }
        else
        {
            thrustEffect.Stop();
        }


    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "asteroidBig" || col.tag == "enemyBullet" || col.tag == "enemyShip" || col.tag == "asteroidMedium" || col.tag == "asteroidSmall")
        {
            
            Instantiate(explosionPlayer, transform.position, new Quaternion());
            Destroy(gameObject, 2f);
            Logic.instance.Die();
            //game over
            //reset level
        }
    }
}
