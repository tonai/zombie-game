using UnityEngine;

public class MenuZombie2 : MonoBehaviour
{
    public Vector3 startPosition;
    // public Quaternion startRotation;

    private Animator animator;
    private Rigidbody rb;
    private BoxCollider bc;
    private float timer;
    private bool dead;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        bc = gameObject.GetComponent<BoxCollider>();
        timer = 0f;
        dead = false;
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

        if ((timer > 60 && timer < 80) || (timer > 90 && timer < 93))
        {
            rb.velocity = Vector3.back * 2;
        }

        if (!dead && timer > 92 && animator)
        {
            dead = true;
            bc.enabled = false;
            animator.SetTrigger("dead");
        }

        if ((timer > 93 && timer < 95))
        {
            gameObject.transform.Translate(Vector3.down * Time.fixedDeltaTime, Space.Self);
        }

        if (timer > 120)
        {
            timer = 0f;
            dead = false;
            bc.enabled = true;
            gameObject.transform.position = startPosition;
            animator.SetTrigger("reset");
            // gameObject.transform.rotation = startRotation;
        }

        if (animator)
        {
            animator.SetFloat("speed", rb.velocity.sqrMagnitude); // sqrMagnitude représente la longueur du vecteur
        }
    }
}
