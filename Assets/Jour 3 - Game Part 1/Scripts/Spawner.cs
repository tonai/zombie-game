using UnityEngine;
using System.Collections.Generic;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public int maxSpawn = 3;
    public float spawnDistance = 30f;
    public float minTime = 5f;
    public float maxTime = 15f;

    private Transform playerTransform;
    private float timer;
    private float timeToSpawn;
    private List<GameObject> instances;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0f;
        timeToSpawn = Random.Range(minTime, maxTime);
        instances = new List<GameObject>();

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

    void FixedUpdate()
    {
        if (!playerTransform || !gameObject)
        {
            return;
        }

        timer += Time.fixedDeltaTime;

        /*
        if (timer > timeToSpawn && spawnNumber < maxSpawn)
        {
            int index = Random.Range(0, prefabs.Length);
            GameObject instance = Instantiate<GameObject>(prefabs[index], gameObject.transform.position, Quaternion.identity);
            spawnNumber++;
            timer = 0f;
            // Debug.Log("Spawning " + instance.name);
        }
        */

        if (Vector3.Distance(gameObject.transform.position, playerTransform.position) < spawnDistance && timer > timeToSpawn && instances.Count < maxSpawn)
        {
            int index = Random.Range(0, prefabs.Length);
            GameObject instance = Instantiate<GameObject>(prefabs[index], gameObject.transform.position, Quaternion.identity);
            Zombie zombieScript = instance.GetComponentInParent<Zombie>();
            if (zombieScript)
            {
                zombieScript.OnKilled += Spawner_RemoveInstance;
            }
            instances.Add(instance);
            timer = 0f;
            timeToSpawn = Random.Range(5f, 15f);
        }
    }

    private void Spawner_RemoveInstance(object sender, System.EventArgs e)
    {
        Zombie zombieScript = sender as Zombie;
        if (zombieScript)
        {
            zombieScript.OnKilled -= Spawner_RemoveInstance;
            instances.Remove(zombieScript.gameObject);
        }
    }

    void OnDrawGizmos()
    {
        if (!playerTransform || !gameObject)
        {
            return;
        }

        if (Vector3.Distance(gameObject.transform.position, playerTransform.position) < spawnDistance)
        {
            Gizmos.color = Color.green;
        }
        else
        {
            Gizmos.color = Color.red;
        }
        Gizmos.DrawLine(gameObject.transform.position + Vector3.up * 0.1f, playerTransform.position + Vector3.up * 0.1f);
    }
}
