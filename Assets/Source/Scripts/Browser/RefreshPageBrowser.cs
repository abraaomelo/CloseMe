using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RefreshPageBrowser : MonoBehaviour
{
    public GameObject browser;
    public GameObject antivirus;
    public GameObject erroBrowser;
    public GameObject loadingObj;

    public void RefreshBrowserAction(){

        
        StartCoroutine(RefreshWithDelay());
    }

    private IEnumerator RefreshWithDelay()
{
    loadingObj.SetActive(true); // Activate loading animation
    yield return new WaitForSeconds(1.5f); // Wait for 1.5 seconds
    
    loadingObj.SetActive(false); // Hide loading animation
    browser.SetActive(!browser.activeSelf);
    antivirus.SetActive(!antivirus.activeSelf);
    erroBrowser.SetActive(false);
}

    
}
