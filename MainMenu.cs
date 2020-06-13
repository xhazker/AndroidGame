using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioMixerGroup Mixer;
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void ChangeMusic(bool enabled)
    {
        if (enabled)
        {
            Mixer.audioMixer.SetFloat("MusicVolume", 0);
            Debug.Log("ON");
        }
        else
        {
            Mixer.audioMixer.SetFloat("MusicVolume", -80);
            Debug.Log("OFF");
        }
        //Mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
    }

    public void ChangeVolume(bool enabled)
    {
        if (enabled)
        {
            Mixer.audioMixer.SetFloat("EffectsVolume", 0);
            Mixer.audioMixer.SetFloat("UIVolume", 0);
        }
        else
        {
            Mixer.audioMixer.SetFloat("EffectsVolume", -80);
            Mixer.audioMixer.SetFloat("UIVolume", -80);
        }

        //Mixer.audioMixer.SetFloat("EffectsVolume", Mathf.Lerp(-40, 0, volume));
        //Mixer.audioMixer.SetFloat("UIVolume", Mathf.Lerp(-80, 0, volume));
    }
}