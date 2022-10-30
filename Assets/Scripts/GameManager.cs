using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject gameOverPanel;
    [SerializeField] TMP_Text gameOverText;
    [SerializeField] PlayerController player;
    [SerializeField] Hole hole;
    [SerializeField] GameObject soundToggle;
    public AudioSource audioSource;
    public AudioClip intoHole;

    private void Start(){
        SoundSystem();
        //gameOverPanel.SetActive(false);
    }

    private void Update(){
        if(hole.Entered && !gameOverPanel.activeInHierarchy){
            audioSource.PlayOneShot(intoHole);
            gameOverPanel.SetActive(true);
            gameOverText.text = "Finished!";
            gameOverText.text = "Shoot Count : " + player.ShootCount;
        }
    }

    public void BackToMainMenu(){
        SceneLoader.Load("MainMenu");
    }

    public void Replay(){
        SceneLoader.ReloadLevel();
    }

    public void PlayNext(){
        SceneLoader.LoadNextLevel();
    }

    private void SoundSystem(){
        float bsound = PlayerPrefs.GetFloat("Sound");
        //Debug.Log(bsound);
        if(bsound == 1){
            audioSource.volume = 1;
            soundToggle.GetComponent<Toggle>().isOn = true;
        }
        else{
            soundToggle.GetComponent<Toggle>().isOn = false;
            audioSource.volume = 0;
        
        }
    }

    public void audioSound(bool on){
        if (on) audioSource.volume = 1;
        else audioSource.volume = 0;
        PlayerPrefs.SetFloat("Sound", audioSource.volume);
    }
}
