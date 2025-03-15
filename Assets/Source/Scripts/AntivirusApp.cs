using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class AntivirusApp : MonoBehaviour
{
    public TextMeshProUGUI threatLevelTxt;
    public float threatLvlPercent = 62;
    public float totalHPStart=62;
    public BrowserController browser;
    public EnvController envController;

    void Start()
    {
        InitialPercentCalc(totalHPStart);
        //threatLevelTxt.text = "%62";
    }

    void Update()
    {
        
    }

    public void InitialPercentCalc(float adHP){
        totalHPStart += adHP;
    }

    public void AddHP(float newAdHP){
        threatLvlPercent += newAdHP;
        threatLevelTxt.text = (threatLvlPercent.ToString()+"%");
    }

    public void AdHit(){
        threatLvlPercent -= 1;
        threatLevelTxt.text = (threatLvlPercent.ToString())+"%";
        if (ReachedZero()){
            Debug.Log("CHEGOU NO ZERO NO ADHIT");
            browser.ReachedZero();
        }

        TextColorChange();
    }

    public float GetCurrentPercent(){
        return threatLvlPercent;
    }
    public bool ReachedZero(){
        if (threatLvlPercent<=0){
            return true;
        }else{
            return false;
        }
    
    }

    public void Ad1stDestroyed(){
        envController.show1stNotification();
    }

    void TextColorChange(){
        // if (threatLvlPercent > 0 && threatLvlPercent <6){
        //     threatLevelTxt.color = Color.green;
        // }else 
        if(threatLvlPercent > 5 && threatLvlPercent < 76){
            threatLevelTxt.color = Color.black;
        }else if (threatLvlPercent >= 76){
            threatLevelTxt.color = Color.red;
        }
    }

    

}
