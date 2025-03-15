using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LimOS : MonoBehaviour
{
    public bool anyWindowOpened = false;
    public Button browserIcon, antivirusIcon, filesIcon, binIcon;


    void Update()
    {
        if(anyWindowOpened){
            BlockDesktopIcons();
        }else{
            UnblockDesktopIcons();
        }
    }

    public void UnblockDesktopIcons(){
        browserIcon.interactable = true;
        antivirusIcon.interactable = true;
        filesIcon.interactable = true;
    }

    public void BlockDesktopIcons(){
        browserIcon.interactable = false;
        antivirusIcon.interactable = false;
        filesIcon.interactable = false;
        Debug.Log("Icons Bloqueados");
    }

    public void WindowOpened(){
        anyWindowOpened = true;
    }

    public void WindowClosed(){
        anyWindowOpened = false;
    }

}
