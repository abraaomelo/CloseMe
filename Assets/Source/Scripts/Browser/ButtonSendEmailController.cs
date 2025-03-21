using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ButtonSendEmailController : MonoBehaviour
{
    public GameObject emailsentScreen;
    public GameObject browser;
    public AntivirusApp antivirus;
    public bool emailSentBool = false;

    public Button mybutton;
    AudioManager audioManager;

    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {
        mybutton.interactable = false;
    }

    void Update()
    {

        if (antivirus.ReachedZero())
        {
            mybutton.interactable = true;
        }
        else if (!antivirus.ReachedZero())
        {
            mybutton.interactable = false;
        }
    }
    public void SendEmail()
    {

        if (antivirus.ReachedZero())
        {
            CallSendEmail();
        }
    }

    private void CallSendEmail()
    {
        browser.SetActive(false);
        emailsentScreen.SetActive(!emailsentScreen.activeSelf);
        Debug.Log("Email enviado");
        emailSentBool = true;
        audioManager.StopMusic();
        audioManager.PlaySFX(audioManager.winnerSound);
    }
}
