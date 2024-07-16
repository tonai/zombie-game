using UnityEngine;

public class AmbiantSoundController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            AudioSource audioSource = gameObject.GetComponent<AudioSource>();
            audioSource.volume = PlayerPrefs.GetFloat("MusicVolume");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
