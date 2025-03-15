using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BrowserDesktop : MonoBehaviour
{
    public Sprite sprhoverBrower, sprunselectedBrowser;
    //public LimOS os;

    void OnMouseEnter()
    {
        Debug.Log("Entrou");
      //  os.WindowOpened();
    }
}
