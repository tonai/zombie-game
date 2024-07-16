using UnityEngine;

public class LookAt : MonoBehaviour
{
    public Transform target;

    // Start is called before the first frame update
    void Start()
    {

        GameObject player = GameObject.Find("Player");
        if (player == null)
        {
            Debug.Log("Player not found");
        }
        else
        {
            target = player.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (target) {
            // gameObject.transform.LookAt(target);
            Vector3 targetPostition = new Vector3(target.position.x, gameObject.transform.position.y, target.position.z);
            gameObject.transform.LookAt(targetPostition);
        }
    }
}
