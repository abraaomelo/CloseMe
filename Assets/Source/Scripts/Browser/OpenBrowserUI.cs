using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenBrowserUI : MonoBehaviour
{
    public GameObject browser, errorBrowser;
    public GameObject antivirus;
    public LimOS os;
    
    public void OpenBrowser(){
        //browser.SetActive(!browser.activeSelf);
        //antivirus.SetActive(!antivirus.activeSelf);
        errorBrowser.SetActive(!errorBrowser.activeSelf);
        os.WindowOpened();
    }
}
