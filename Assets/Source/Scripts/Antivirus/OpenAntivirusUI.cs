using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAntivirusUI : MonoBehaviour
{
    public AntivirusApp antivirus;
    public LimOS os;

    public bool openableIconAntivirus;

    public void OpenAntivirus()
    {
        Debug.Log("Clicou na barra ");
            antivirus.gameObject.SetActive(!antivirus.gameObject.activeSelf);
            os.WindowOpened();
        
    }
}
