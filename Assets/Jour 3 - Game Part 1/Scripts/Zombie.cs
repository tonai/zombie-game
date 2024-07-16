using System;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float speed = 5f;
    public int damage = 1;
    public float attackDistance = 1.5f;
    public float attackTime = 2f;
    public Rigidbody rb;
    public event EventHandler OnKilled;

    private Transform playerTransform;
    private bool isAttacking = false;
    private float attackTimer = 0f;
    private Animator animator;
    private bool canMove = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        canMove = false;

        GameObject player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.Log("Player not found");
        }
        else
        {
            playerTransform = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // rb = gameObject.GetComponent<Rigidbody>();
    }

    public void Activate()
    {
        canMove = true;
        attackTimer = 0f;
        isAttacking = false;
    }

    public void Deactivate()
    {
        canMove = false;
    }


    public void Hit()
    {
        Activate();

        if (Vector3.Distance(gameObject.transform.position, playerTransform.position) < attackDistance)
        {
            Life lifeScript = playerTransform.GetComponent<Life>();
            if (lifeScript)
            {
                lifeScript.Damage(damage);
            }
        }
    }

    public void Kill()
    {
        OnKilled?.Invoke(this, EventArgs.Empty);
        Destroy(gameObject);
    }

    // Boucle du moteur physique (entre 30 et 60 fois par secondes) alors que le jeu et la boucle Update peut tourner beaucoup plus vite (et causer des glitchs)
    void FixedUpdate()
    {
        if (!playerTransform || !gameObject)
        {
            return;
        }

        if (Vector3.Distance(gameObject.transform.position, playerTransform.position) > attackDistance)
        {
            if (canMove) {
                Vector3 playerPosition = playerTransform.position;
                Vector3 zombiePosition = gameObject.transform.position;

                Vector3 direction = playerPosition - zombiePosition;
                direction.y = 0f; // We only want X and Z directions

                // No need to use Time.deltaTime for velocity
                rb.velocity = direction.normalized * speed + rb.velocity.y * Vector3.up; // We reuse the last value for Y only
                attackTimer = 0f;
                isAttacking = false;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
            if (animator && !isAttacking)
            {
                animator.SetTrigger("attack");
                isAttacking = true;
            }
            attackTimer += Time.fixedDeltaTime;
        }

        if (animator)
        {
            animator.SetFloat("speed", rb.velocity.sqrMagnitude); // sqrMagnitude représente la longueur du vecteur
        }
    }

    void OnDrawGizmos()
    {
        if (!playerTransform || !gameObject)
        {
            return;
        }

        if (Vector3.Distance(gameObject.transform.position, playerTransform.position) > attackDistance)
        {
            Gizmos.color = Color.red;
        }
        else
        {
            Gizmos.color = Color.green;
        }
        Gizmos.DrawLine(gameObject.transform.position + Vector3.up * 0.1f, playerTransform.position + Vector3.up * 0.1f);
    }
}
