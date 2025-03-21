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
    public GameObject desktopIcon1, desktopIcon2, desktopIcon3;
    public GameObject tr0janObj;
    private bool reachedZero = false;
    private int lastAd = -1, randomAd;
    public float value = 10f;
    public Transform adZone;
    Vector2 minBounds, maxBounds;
    AudioManager audioManager;



    void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {

        minBounds = new Vector2(-3.34f, -0.46f);
        maxBounds = new Vector2(2.7f, 2.34f);
        audioManager.PlayMusic(audioManager.shootingGame);
        CreateTr0jan();
        StartCoroutine(SpawnAdsWithDelay());
        StartCoroutine(SpawnTr0janWithDelay());

    }
    void Update()
    {
        CheckIfReachedZero();

        if (Input.GetKeyDown(KeyCode.N))
        {
            CreateRandomAd();
        }
    }

    private void CheckIfReachedZero()
    {
        if (antivirus.GetCurrentPercent() < 1)
        {
            reachedZero = true;
        }
    }


    IEnumerator CheckAfterDelay()
    {
        yield return new WaitForSeconds(3f); // Wait for 5 seconds

        CreateRandomAd();
        reachedZero = false;
    }

    IEnumerator CreateNewTr0janDelay()
    {
        yield return new WaitForSeconds(3f); // Wait for 5 seconds
        CreateTr0jan();
    }

    public void ReachedZero()
    {
        StartCoroutine(CheckAfterDelay());
    }

    public void CreateRandomAd()
    {
        Vector2 randomPosition = new Vector2(
            Random.Range(minBounds.x, maxBounds.x),
            Random.Range(minBounds.y, maxBounds.y)
        );

        do
        {
            randomAd = Random.Range(1, 6);  // Random number between 1 and 5

        } while (randomAd == lastAd);

        lastAd = randomAd;



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
                newAdG = Instantiate(adP1Prefab, randomPosition, Quaternion.identity);
                newAdG.GetComponent<AdPController>().SetAntivirus(antivirus);
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
    }

    void CreateTr0jan()
    {
       // tr0janObj.SetActive(!tr0janObj.activeSelf);
        Instantiate(tr0janObj, Vector3.zero, Quaternion.identity);

    }

    public void SetAntivirus(AntivirusApp app)
    {
        antivirus = app;
    }

    IEnumerator SpawnAdsWithDelay()
    {
        for (int i = 0; i < 2; i++)
        {
            CreateRandomAd();
            yield return new WaitForSeconds(2f);
        }
        for (int i = 0; i < 5; i++)
        {
            CreateRandomAd();
            yield return new WaitForSeconds(0.4f);
        }

    }

    IEnumerator SpawnTr0janWithDelay()
    {
        for (int i = 0; i < 10; i++)
        {
            CreateTr0jan();
            yield return new WaitForSeconds(3f); 
        }
    }



}
