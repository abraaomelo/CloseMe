using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RefreshPageBrowser : MonoBehaviour
{
    public GameObject browser;
    public GameObject antivirus;
    public GameObject erroBrowser;

    public void RefreshBrowserAction(){
       
        browser.SetActive(!browser.activeSelf);
        antivirus.SetActive(!antivirus.activeSelf);
         erroBrowser.SetActive(false);
    }
}
