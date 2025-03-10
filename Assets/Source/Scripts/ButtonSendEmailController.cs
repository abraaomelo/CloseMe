using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonSendEmailController : MonoBehaviour
{
    public GameObject emailsentScreen;
    public GameObject browser;
    public AntivirusApp antivirus;
    public bool emailSentBool=false;
    public void SendEmail(){
        
        if (antivirus.ReachedZero()){
        CallSendEmail();
        }
    }

    private void CallSendEmail(){
        browser.SetActive(false);
        emailsentScreen.SetActive(!emailsentScreen.activeSelf);
        Debug.Log("Email enviado");
        emailSentBool = true;
    }
}
