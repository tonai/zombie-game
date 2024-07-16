using UnityEngine;
using System;

public static class SoundManager
{
    private static GameObject oneShotGameObject;
    private static AudioSource oneShotAudioSource;
    private static float fxVolume = 2f;

    public static void PlaySound(AudioClip sound)
    {
        if (!oneShotGameObject)
        {
            oneShotGameObject = new GameObject("One shot sound");
            oneShotAudioSource = oneShotGameObject.AddComponent<AudioSource>();
        }
        oneShotAudioSource.PlayOneShot(sound);
    }
    public static void PlaySound(AudioClip sound, Vector3 position)
    {
        GameObject soundGameObject = new GameObject("sound");
        soundGameObject.transform.position = position;
        AudioSource audioSource = soundGameObject.AddComponent<AudioSource>();
        audioSource.clip = sound;
        audioSource.maxDistance = 30f;
        audioSource.spatialBlend = 1f;
        audioSource.rolloffMode = AudioRolloffMode.Linear;
        audioSource.dopplerLevel = 0f;
        float volume = getFxVolume();
        audioSource.volume = volume;
        audioSource.Play();
        UnityEngine.Object.Destroy(soundGameObject, audioSource.clip.length);
    }

    private static float getFxVolume()
    {
        if (fxVolume == 2f)
        {
            if (PlayerPrefs.HasKey("FxVolume"))
            {
                fxVolume = PlayerPrefs.GetFloat("FxVolume");
            }
            else
            {
                fxVolume = 0.5f;
            }
        }
        return Math.Min(fxVolume, 1f);
    }
}
