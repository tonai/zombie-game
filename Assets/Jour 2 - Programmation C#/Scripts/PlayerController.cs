using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Unused
    /*
    public int score = 0;
    public bool checkbox = false;
    public Vector3 startPosition = new Vector3(0f, 0f, 0f); // vecteur 3 dimensions X, Y, Z
    */

    // Movement speed
    public float speed = 10.0f;

    // Rotation speed
    public float rotateSpeed = 90.0f;

    // Inputs
    /*
    public KeyCode forward;
    public KeyCode backward;
    public KeyCode right;
    public KeyCode left;
    */
    // public InputActionAsset playerControls;

    private Animator animator;
    private Rigidbody rb;
    private PlayerInput pi;
    /*
    public InputAction up;
    public InputAction down;
    public InputAction left;
    public InputAction right;
    */
    // private InputAction movement;

    // Movement
    // private float Vertical => Input.GetAxis("Vertical");
    /*
    private float Vertical
    {
        get
        {
            var keyboard = Keyboard.current;
            var vertical = 0;
            if (keyboard.wKey.isPressed)
            {
                vertical = 1;
            }
            else if (keyboard.sKey.isPressed)
            {
                vertical = -1;
            }
            return vertical;
        }
    }
    */
    // private float Vertical { set; get; }
    private float vertical;
    // private float Horizontal => Input.GetAxis("Horizontal");
    /*
    private float Horizontal
    {
        get
        {
            var keyboard = Keyboard.current;
            var horizontal = 0;
            if (keyboard.dKey.isPressed)
            {
                horizontal = 1;
            }
            else if (keyboard.aKey.isPressed)
            {
                horizontal = -1;
            }
            return horizontal;
        }
    }
    */
    // private float Horizontal { set; get; }
    private float horizontal;

    // private bool IsMoving => Direction != Vector3.zero;
    // private Vector3 Direction => new Vector3(Horizontal, 0, Vertical);
    // private Quaternion Rotation => Quaternion.LookRotation(RotationDirection);
    // private Vector3 RotationDirection => Vector3.RotateTowards(transform.forward, Direction, rotateSpeed * Time.deltaTime, 0);

    /*
    private void Awake()
    {
        // up.performed += context => Vertical = 1;
        // up.canceled += context => Vertical = 0;
        // down.performed += context => Vertical = -1;
        // down.canceled += context => Vertical = 0;
        // right.performed += context => Horizontal = 1;
        // right.canceled += context => Horizontal = 0;
        // left.performed += context => Horizontal = -1;
        // left.canceled += context => Horizontal = 0;
        // var gamePlayActionMap = playerControls.FindActionMap("Player");
        // movement = gamePlayActionMap.FindAction("Move");
        // movement.performed += OnMovementPerformed;
        // movement.canceled += OnMovementPerformed;
    }

    private void OnDisable()
    {
        // up.Disable();
        // down.Disable();
        // right.Disable();
        // left.Disable();
        // movement.Disable();
    }

    private void OnEnable()
    {
        // up.Enable();
        // down.Enable();
        // right.Enable();
        // left.Enable();
        // movement.Enable();
    }
    */
    public PlayerInput PlayerInput => pi;

    // Start is called before the first frame update
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        rb = gameObject.GetComponent<Rigidbody>();
        pi = gameObject.GetComponent<PlayerInput>();
        // gameObject.transform.position = startPosition;
    }

    // Update is called once per frame
    /*
    void Update()
    {
        // Permet de mettre à jour la position en modifiant via l'interface de unity pendant que le jeu tourne.
        // gameObject.transform.position = startPosition;

        // if (Input.GetKey(forward))
        {
            // Debug.Log("Forward");
            // gameObject.transform.position += new Vector3(0f, 0f, speed * Time.deltaTime);
            // gameObject.transform.position += gameObject.transform.forward * speed * Time.deltaTime;
            gameObject.transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self); // Vector3.forward = new Vector3(0f, 0f, 1f)
        }
        if(Input.GetKey(backward))
        {
            // Debug.Log("Backward");
            // gameObject.transform.position += new Vector3(0f, 0f, -speed * Time.deltaTime);
            // gameObject.transform.position -= gameObject.transform.forward * speed * Time.deltaTime;
            gameObject.transform.Translate(- Vector3.forward * speed * Time.deltaTime, Space.Self); // Vector3.forward = new Vector3(0f, 0f, 1f)
        }
        if (Input.GetKey(right))
        {
            // Debug.Log("Right");
            // gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            gameObject.transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(left))
        {
            // Debug.Log("Left");
            // gameObject.transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
            gameObject.transform.Rotate(0f, -rotateSpeed * Time.deltaTime, 0f);
        }
    }
    */

    void FixedUpdate()
    {
        // float vertical = Input.GetAxis("Vertical");
        // float horizontal = Input.GetAxis("Horizontal");

        //Déplacement "avancer" et "reculer", en ajoutant une force de translation
        // rb.AddForce(gameObject.transform.forward * vertical * speed);
        rb.velocity = gameObject.transform.forward * vertical * speed + rb.velocity.y * Vector3.up;

        //Déplacement "gauche" et "droite" suivant l'axe Y, ajoute une force de rotation
        // rb.AddTorque(Vector3.up * horizontal * rotateSpeed);
        gameObject.transform.Rotate(0f, rotateSpeed * horizontal * Time.deltaTime, 0f);


        // Je récupère la variable "speed" dans l'animator est je lui affecte la vitesse de déplacement de mon zombie
        if (animator)
        {
            animator.SetFloat("speed", rb.velocity.magnitude * Mathf.Sign(vertical));
        }
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        Vector2 direction = context.ReadValue<Vector2>();
        horizontal = direction.x;
        vertical = direction.y;
    }
}
