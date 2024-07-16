using UnityEngine;

public class AnimatorScript : MonoBehaviour
{
    public GameObject deathParticule;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Destroy()
    {
        Instantiate<GameObject>(deathParticule, gameObject.transform.position, Quaternion.identity);
        Zombie zombieScript = gameObject.GetComponentInParent<Zombie>();
        if (zombieScript)
        {
            zombieScript.Kill();
        }
        else
        {
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    public void Activate()
    {
        Zombie zombieScript = gameObject.GetComponentInParent<Zombie>();
        if (zombieScript)
        {
            zombieScript.Activate();
        }
    }

    public void Deactivate()
    {
        Zombie zombieScript = gameObject.GetComponentInParent<Zombie>();
        if (zombieScript)
        {
            zombieScript.Deactivate();
        }
    }

    public void Hit()
    {
        Zombie zombieScript = gameObject.GetComponentInParent<Zombie>();
        if (zombieScript)
        {
            zombieScript.Hit();
        }
    }
}
