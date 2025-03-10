using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBrowserUI : MonoBehaviour
{
    public GameObject browser;
    public GameObject antivirus;

    
    public void OpenBrowser(){
        browser.SetActive(!browser.activeSelf);
        antivirus.SetActive(!antivirus.activeSelf);
    }
}
