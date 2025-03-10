using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject sendEmailbtnOBJ;
    public void RetryButtonAction(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void GotToMenu(){
        SceneManager.LoadScene(1);
    }

    public void ActivateSendEmailBttn(){
        sendEmailbtnOBJ.SetActive(!sendEmailbtnOBJ.activeSelf);
    }
}
