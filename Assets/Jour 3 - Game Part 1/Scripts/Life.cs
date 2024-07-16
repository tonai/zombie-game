using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public int life = 1;
    public GameObject bloodParticule;
    public Text textLife;
    public AudioClip deathSound;
    // public UnityEvent death;

    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Damage(int damage)
    {
        life -= damage;
        UpdateText();

        if (bloodParticule)
        {
            Instantiate<GameObject>(bloodParticule, gameObject.transform.position, Quaternion.identity);
        }

        if (life == 0)
        {
            if (gameObject.name == "Player")
            {
                // Use an event.
                /*
                if (death != null)
                {
                    death.Invoke();
                }
                */
                SceneManager.LoadScene("GameOver");
            }
            else {
                if (animator)
                {
                    animator.SetTrigger("dead");
                }
                else
                {
                    Destroy(gameObject);
                }

                Zombie zombieScript = gameObject.GetComponent<Zombie>();
                if (zombieScript)
                {
                    zombieScript.Deactivate();
                }
                if (deathSound)
                {
                    SoundManager.PlaySound(deathSound, gameObject.transform.position);
                }
            }
        }
        else if (life > 0)
        {
            if (animator)
            {
                animator.SetTrigger("hit");
            }
        }
    }

    public void UpdateText()
    {
        if (textLife)
        {
            textLife.text = "Life: " + life;
        }
    }
}
