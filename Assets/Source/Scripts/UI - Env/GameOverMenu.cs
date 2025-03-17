using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject sendEmailbtnOBJ;
    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        audioManager.PlayMusic(audioManager.gameOver);
    }
    public void RetryButtonAction(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GotToMenu(){
        SceneManager.LoadScene(0);
    }

    public void ActivateSendEmailBttn(){
        sendEmailbtnOBJ.SetActive(!sendEmailbtnOBJ.activeSelf);
    }
}
