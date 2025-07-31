using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrowserTutorial : MonoBehaviour
{
    public GameObject ad1Test;
    public GameObject arrowAntivirus;
    public OpenAntivirusUI antivirusTaskBar;


    public void ActivateTutorialAd(){
        ad1Test.SetActive(!ad1Test.activeSelf);
        arrowAntivirus.SetActive(!arrowAntivirus.activeSelf);
        antivirusTaskBar.OpenAntivirus();
    }
}
