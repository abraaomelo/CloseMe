using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBrowserUI : MonoBehaviour
{
    public GameObject browser, errorBrowser, errorBrowserLoad, loadingObj;
    public GameObject antivirus;
    public LimOS os;
    
    public void OpenBrowser(){
        //browser.SetActive(!browser.activeSelf);
        //antivirus.SetActive(!antivirus.activeSelf);
        //errorBrowser.SetActive(!errorBrowser.activeSelf);
        errorBrowserLoad.SetActive(!errorBrowserLoad.activeSelf);
        loadingObj.SetActive(!loadingObj.activeSelf);
        StartCoroutine(LoadPageDelay());
        os.WindowOpened();
    }



    IEnumerator LoadPageDelay(){
        yield return new WaitForSeconds(2.5f);
        errorBrowserLoad.SetActive(false);
        loadingObj.SetActive(false);
        errorBrowser.SetActive(!browser.activeSelf);
    }
}
