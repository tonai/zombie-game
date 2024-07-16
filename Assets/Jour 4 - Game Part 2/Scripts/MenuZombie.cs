using UnityEngine;

public class MenuZombie : MonoBehaviour
{
    public Vector3 startPosition;
    // public Quaternion startRotation;

    private Animator animator;
    private Rigidbody rb;
    private float timer;
    private bool forward;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        timer = 0f;
        forward = true;
        gameObject.transform.position = startPosition;
        // gameObject.transform.rotation = startRotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (!gameObject)
        {
            return;
        }

        timer += Time.fixedDeltaTime;

        if (timer < 20 || (timer > 30 && timer < 50)) {
            rb.velocity = Vector3.right;
            // rb.AddForce(gameObject.transform.forward * 12f);
        }


        if (forward && timer > 55)
        {
            forward = false;
            // gameObject.transform.rotation = Quaternion.Inverse(gameObject.transform.rotation);
            gameObject.transform.rotation *= Quaternion.Euler(0, 180, 0);
        }


        if (timer > 100 && timer < 110)
        {
            rb.velocity = Vector3.left * 5;
            // rb.AddForce(gameObject.transform.forward * 15f);
        }

        if (timer > 120)
        {
            timer = 0f;
            forward = true;
            gameObject.transform.position = startPosition;
            gameObject.transform.rotation *= Quaternion.Euler(0, 180, 0);
            // gameObject.transform.rotation = startRotation;
        }

        if (animator)
        {
            animator.SetFloat("speed", rb.velocity.sqrMagnitude); // sqrMagnitude représente la longueur du vecteur
        }
    }
}
