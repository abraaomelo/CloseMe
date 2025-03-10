using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsEnvController : MonoBehaviour
{
    private float adsStartFullHP;
    private float adsCrrntHP;
    public AntivirusApp antivirus;
    public BrowserController browser;
    
    public void StartAdsHPSum(float adFullHealth){
        adsStartFullHP = adsStartFullHP + adFullHealth;    
    }


}
