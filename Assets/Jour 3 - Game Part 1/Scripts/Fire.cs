using UnityEngine;
using UnityEngine.InputSystem;

public class Fire : MonoBehaviour
{
    public GameObject bullet;
    public Transform riffle;
    // public KeyCode fireKey;
    public float fireRate = 0.3f;
    public AudioClip attackSound;
    public GameObject fireParticule;

    // private float fire => Input.GetAxis("Fire1");
    /*
    private float fire
    {
        get
        {
            var keyboard = Keyboard.current;
            var fire = 0;
            if (keyboard.spaceKey.isPressed)
            {
                fire = 1;
            }
            return fire;
        }
    }
    */
    private float fire;

    private Animator animator;
    private float timer;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        timer = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // float fire = Input.GetAxis("Fire1");
        timer += Time.fixedDeltaTime;

        if (fire > 0 && timer > fireRate)
        {
            Vector3 position = riffle ? riffle.position : gameObject.transform.position;
            Instantiate<GameObject>(bullet, position, gameObject.transform.rotation);
            if (attackSound) {
                SoundManager.PlaySound(attackSound, position);
            }
            if (fireParticule)
            {
                Instantiate<GameObject>(fireParticule, position, Quaternion.identity);
            }
            if (animator)
            {
                animator.SetTrigger("shoot");
            }
            timer = 0;
        }
    }

    public void OnFire(InputAction.CallbackContext context)
    {
        fire = context.ReadValue<float>();
    }
}
