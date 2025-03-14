using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAntivirusUI : MonoBehaviour
{
    public GameObject antivirus;

    
    public void OpenAntivirus(){
        antivirus.SetActive(!antivirus.activeSelf);
    }
}
