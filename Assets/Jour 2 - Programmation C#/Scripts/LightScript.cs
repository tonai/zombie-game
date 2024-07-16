using UnityEngine;

public class LightScript : MonoBehaviour
{
    public Light sun;
    // public Light light1;
    // public Light light2;
    // public Light light3;
    // public Light light4;
    // public Light light5;
    // public Light light6;
    public Light[] lights;

    // public GameObject prefab;
    // Use following line to create a spawner:
    // Instantiate<GameObject>(prefab, position, Quaternion.identity);

    public void ToggleLights()
    {
        for (int i = 0; i < lights.Length; i++)
        {
            if (lights[i] != null)
            {
                lights[i].enabled = !lights[i].enabled;
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            sun.enabled = !sun.enabled;
            /*
            if (sun.intensity == 0f)
            {
                sun.intensity = 1f;
            }
            else
            {
                sun.intensity = 0f;
            }
            */
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // sun.intensity = 0f;
        // light1.intensity = 0f;
        // light2.intensity = 0f;
        // light3.intensity = 0f;
        // light4.intensity = 0f;
        // light5.intensity = 0f;
        // light6.intensity = 0f;
        ToggleLights();
        Debug.Log("Off");
    }

    void OnTriggerExit(Collider other)
    {
        // sun.intensity = 1f;
        // light1.intensity = 38f;
        // light2.intensity = 38f;
        // light3.intensity = 38f;
        // light4.intensity = 38f;
        // light5.intensity = 38f;
        // light6.intensity = 38f;
        ToggleLights();
        Debug.Log("On");
    }
}
