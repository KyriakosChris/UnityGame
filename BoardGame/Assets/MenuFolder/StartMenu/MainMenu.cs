using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    public void PlayGame()
    {
        // Loads the game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    { 
        Application.Quit();
    }


    public void SetVolume ( float volume)
    {
        // SetTheVolume in the Mixer
        audioMixer.SetFloat("volume",volume);
    }

}
