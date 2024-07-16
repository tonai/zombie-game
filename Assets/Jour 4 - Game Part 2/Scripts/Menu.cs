using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject ambientSound;
    public GameObject musicVolumeSlider;
    public GameObject fxVolumeSlider;

    void Awake()
    {
        GameObject[] menus = GameObject.FindGameObjectsWithTag("Menu");
        foreach (GameObject menu in menus)
        {
            menu.SetActive(false);
        }
        mainMenu.SetActive(true);

        if (!PlayerPrefs.HasKey("MusicVolume"))
        {
            PlayerPrefs.SetFloat("MusicVolume", 0.5f);
        }
        if (!PlayerPrefs.HasKey("FxVolume"))
        {
            PlayerPrefs.SetFloat("FxVolume", 0.5f);
        }
    }
    void Start()
    {
        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            Slider slider = musicVolumeSlider.GetComponent<Slider>();
            slider.value = PlayerPrefs.GetFloat("MusicVolume");
        }

        if (PlayerPrefs.HasKey("FxVolume"))
        {
            Slider slider = fxVolumeSlider.GetComponent<Slider>();
            slider.value = PlayerPrefs.GetFloat("FxVolume");
        }
    }

    public void UpdateMusicVolume(float value)
    {
        PlayerPrefs.SetFloat("MusicVolume", value);
        if (ambientSound != null) {
            AudioSource audioSource = ambientSound.GetComponent<AudioSource>();
            audioSource.volume = value;
        }
    }


    public void UpdateFxVolume(float value)
    {
        PlayerPrefs.SetFloat("FxVolume", value);
    }
}
