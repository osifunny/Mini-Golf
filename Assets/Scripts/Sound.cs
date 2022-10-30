using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sound : MonoBehaviour
{
    public AudioSource audioSource;
    public Toggle sound;

    private void Start(){
        SoundSystem();
    }

    private void SoundSystem(){
        float bsound = PlayerPrefs.GetFloat("Sound");
        if(bsound == 1) audioSource.volume = 1;
        else audioSource.volume = 0;
    }

    public void audioSound(bool on){
        if (on) audioSource.volume = 1;
        else audioSource.volume = 0;
        PlayerPrefs.SetFloat("Sound", audioSource.volume);
    }
}
