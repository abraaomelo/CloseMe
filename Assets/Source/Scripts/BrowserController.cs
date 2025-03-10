using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BrowserController : MonoBehaviour
{
    public AntivirusApp antivirus;
   // Ad Prefabs
    public GameObject adM1Prefab;
    public GameObject adG1Prefab;
    public GameObject adM2Prefab;
    public GameObject adP1Prefab;
    public GameObject adP2Prefab;
    private bool reachedZero=false;
    public float value = 10f;
    public Transform adZone;
    Vector2 minBounds, maxBounds;

    void Start()
    {
        //minBounds = new Vector2(-6.34f, -1.46f);
        minBounds = new Vector2(-3.34f, -0.46f);
        //maxBounds = new Vector2(7.7f, 4.34f);
        maxBounds = new Vector2(2.7f, 2.34f);
    }
    void Update()
    {
        CheckIfReachedZero();
    }

    private void CheckIfReachedZero(){
        if (antivirus.GetCurrentPercent()<1){
            reachedZero=true;
           
            reachedZero=false;
        }
    }


    IEnumerator CheckAfterDelay()
    {
        Debug.Log("VENDO SE ENTRA");
        yield return new WaitForSeconds(1f); // Wait for 5 seconds

        Vector2 randomPosition = new Vector2(
            Random.Range(minBounds.x, maxBounds.x),
            Random.Range(minBounds.y, maxBounds.y)
        );

            // GameObject newAdG = Instantiate(adM1Prefab, randomPosition, Quaternion.identity);
            // newAdG.GetComponent<AdMController>().SetAntivirus(antivirus);
            
            int randomAd = Random.Range(1, 6);  // Random number between 1 and 5
        
        GameObject newAdG = null;

        switch (randomAd)
        {
            case 1:
                newAdG = Instantiate(adM1Prefab, randomPosition, Quaternion.identity);
                newAdG.GetComponent<AdMController>().SetAntivirus(antivirus);
                break;
            case 2:
                newAdG = Instantiate(adM1Prefab, randomPosition, Quaternion.identity);
                newAdG.GetComponent<AdMController>().SetAntivirus(antivirus);
                break;
            case 3:
                newAdG = Instantiate(adG1Prefab, randomPosition, Quaternion.identity);
                newAdG.GetComponent<AddGController>().SetAntivirus(antivirus);
                break;
            case 4:
                newAdG = Instantiate(adP1Prefab, randomPosition, Quaternion.identity);
                newAdG.GetComponent<AdPController>().SetAntivirus(antivirus);
                break;
            case 5:
                newAdG = Instantiate(adP2Prefab, randomPosition, Quaternion.identity);
                newAdG.GetComponent<AdPController>().SetAntivirus(antivirus);
                break;
            default:
                Debug.LogError("Invalid ad selection");
                break;
        }
            reachedZero=false;
    }

    public void ReachedZero(){
        StartCoroutine(CheckAfterDelay());
    }

}
