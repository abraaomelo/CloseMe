using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using System;

public class EnvController : MonoBehaviour
{
    public GameObject objectiveNotification, keepGoingNotification, timerNotification;
    public AntivirusApp antivirus;
     private bool ad1stDestroy = false;
     private bool ad2ndDestroy= false;
     public float countdownTimer = 10f;
     public float currentTime = 20f;
     public TextMeshProUGUI countdownText;
     public GameObject gameOverScreen;

      public GameObject pauseObj;

     private bool active = true;
     private bool gameOver = false;

     public bool gameStopped = false;

     public GameObject gun;

     public ButtonSendEmailController emailController;
     AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        // if (gameOverScreen != null)
        // gameOverScreen.SetActive(false);

        // StartCoroutine(Countdown());

        //countdownText.text = "EDITEI TESTE";
    }

    void Update(){
        if(!emailController.emailSentBool && antivirus.isActiveAndEnabled)
            TimerCount();
        
            if(Input.GetKeyDown(KeyCode.Escape)) {
                OpenPause();
            }
    }

    void TimerCount(){
        if (!active)
        return;

        currentTime -= Time.deltaTime;
        UpdateTimerUI();

        if (currentTime <= 0){
            StopTimer();
        }
    }

    void OpenPause(){

        pauseObj.SetActive(!pauseObj.activeSelf);
        
    }
    

    void UpdateTimerUI(){
        if (currentTime > 0 && currentTime <6){
            countdownText.color = Color.red;
        }else if(currentTime < 1){
            countdownText.color = Color.magenta;
        }

        TimeSpan t = TimeSpan.FromSeconds(currentTime);
        countdownText.text = t.ToString(@"mm\:ss");
    }

    void StopTimer(){
        active = false;
        currentTime = 0f;
        UpdateTimerUI();
        GameOver();
    }

    // IEnumerator Countdown(){
        
    //     Debug.Log("//Countdown chamado 111");
    //     while (countdownTimer > 0){
    //         countdownTimer -= Time.deltaTime;
    //         Debug.Log("Entrtou aqui"+ countdownTimer);
    //         countdownText.text = Mathf.Ceil(countdownTimer).ToString();
    //         if (countdownText != null)
    //         Debug.Log("Countdown não nulo");
                
    //     }
    // yield return null;
    //     //GameOver();
    // }

    

    void GameOver(){
        if (gameOver) return;
        gameOver = true;

        if (gameOverScreen != null)
            gameOverScreen.SetActive(true);
            gun.SetActive(false);
            //StartCoroutine(RestartGame());
    }

    IEnumerator RestartGame(){
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void show1stNotification(){
        if(!ad1stDestroy){
        keepGoingNotification.SetActive(!keepGoingNotification.activeSelf);
        ad1stDestroy = true;
        audioManager.PlaySFX(audioManager.notificationAlert);
        }else if(!ad2ndDestroy){
            show2ndNotification();
            ad2ndDestroy=true;
            audioManager.PlaySFX(audioManager.notificationAlert);
        }
    }

    private void show2ndNotification(){
        timerNotification.SetActive(!timerNotification.activeSelf);
        keepGoingNotification.SetActive(false);
    }

}
