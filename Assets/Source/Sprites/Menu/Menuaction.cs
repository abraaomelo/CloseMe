using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menuaction : MonoBehaviour
{
    public GameObject credits;
    public GameObject menuprincipal;

    private SoundHandler sh;

    public void Start()
    {
        sh = GetComponent<SoundHandler>();
        //sh.PlayBgSong();    
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
        Debug.Log("Sair do Jogo");
    }
}
