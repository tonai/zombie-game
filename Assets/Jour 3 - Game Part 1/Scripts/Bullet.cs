using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 50f;
    public int damage = 1;
    public float lifetime = 2f;
    public GameObject impactParticule;

    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.velocity = gameObject.transform.forward * speed;
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        Life lifeScript = collision.gameObject.GetComponent<Life>();
        if (lifeScript)
        {
            lifeScript.Damage(damage);
        }
        else
        {
            Instantiate<GameObject>(impactParticule, gameObject.transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }
}
