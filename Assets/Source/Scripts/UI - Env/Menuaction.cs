using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuaction : MonoBehaviour
{
    public GameObject credits;
    public GameObject menuprincipal;



    public void Start()
    {
  
    }

    public void StartGame(){
        SceneManager.LoadScene(1);
        Debug.Log("Começar Jogo");
    }

    public void OpenCredits()
    {
        menuprincipal.SetActive(false);
        credits.SetActive(!credits.activeSelf);
    }

    public void CloseCredits()
    {
        credits.SetActive(false);
        menuprincipal.SetActive(!menuprincipal.activeSelf);
    }

    public void ExitGame() {
        Application.OpenURL("https://nukkensa.itch.io/close-me-if-you-can");
    }
}
