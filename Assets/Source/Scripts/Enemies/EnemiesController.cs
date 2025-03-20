using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesController : MonoBehaviour
{
    public GameObject adM1Prefab;
    public GameObject adG1Prefab;
    public GameObject adM2Prefab;
    public GameObject adP1Prefab;
    public GameObject adP2Prefab;
     Vector2 minBounds, maxBounds;
     public AntivirusApp antivirus;
    public BrowserController browser;
     

    private void Start()
     {
        
        minBounds = new Vector2(-5.79f, -1.38f);
        maxBounds = new Vector2(3.71f, 3.84f); 

     }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M)){
            browser.CreateRandomAd();
        }
    }


  
}
