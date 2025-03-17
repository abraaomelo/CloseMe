using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenFilesUI : MonoBehaviour
{
    public GameObject fileExplorer;

    
    public void OpenFies(){
        fileExplorer.SetActive(!fileExplorer.activeSelf);
    }
}
