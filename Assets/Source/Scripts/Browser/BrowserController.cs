using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class BrowserController : MonoBehaviour
{
    public AntivirusApp antivirus;
    // Ad Prefabs
    public GameObject adM1Prefab;
    public GameObject adM2Prefab;
    public GameObject adM3Prefab;
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
     private List<int> adPool = new List<int>() { 1, 2, 3, 4, 5 };

    ///-------------------------- Começou a mudança aqui hein -------------------------------//


    private Queue<int> adQueue = new Queue<int>();
    private List<int> adList = new List<int> { 1, 2, 3, 4, 5 };

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
        FillAndShuffleAdPool();

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

    // public void CreateRandomAd()
    // {
    //     Vector2 randomPosition = new Vector2(
    //         Random.Range(minBounds.x, maxBounds.x),
    //         Random.Range(minBounds.y, maxBounds.y)
    //     );

    //     do
    //     {
    //         randomAd = Random.Range(1, 6);  // Random number between 1 and 5

    //     } while (randomAd == lastAd);

    //     lastAd = randomAd;



    //     GameObject newAdG = null;

    //     switch (randomAd)
    //     {
    //         case 1:
    //             newAdG = Instantiate(adM1Prefab, randomPosition, Quaternion.identity);
    //             newAdG.GetComponent<AdMController>().SetAntivirus(antivirus);
    //             break;
    //         case 2:
    //             newAdG = Instantiate(adM2Prefab, randomPosition, Quaternion.identity);
    //             newAdG.GetComponent<AdMController>().SetAntivirus(antivirus);
    //             break;
    //         case 3:
    //             newAdG = Instantiate(adM3Prefab, randomPosition, Quaternion.identity);
    //             newAdG.GetComponent<AdMController>().SetAntivirus(antivirus);
    //             break;
    //         case 4:
    //             newAdG = Instantiate(adP1Prefab, randomPosition, Quaternion.identity);
    //             newAdG.GetComponent<AdPController>().SetAntivirus(antivirus);
    //             break;
    //         case 5:
    //             newAdG = Instantiate(adP2Prefab, randomPosition, Quaternion.identity);
    //             newAdG.GetComponent<AdPController>().SetAntivirus(antivirus);
    //             break;
    //         default:
    //             Debug.LogError("Invalid ad selection");
    //             break;
    //     }
    // }

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
        for (int i = 0; i < 30; i++)
        {
            CreateTr0jan();
            yield return new WaitForSeconds(2f);
        }
    }

    //--------------------NEUE--------------------------

    private void FillAndShuffleAdPool()
    {
        adPool = new List<int> { 1, 2, 3, 4, 5 };
        Shuffle(adPool);
    }

    private void Shuffle(List<int> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (list[i], list[j]) = (list[j], list[i]); // Swap
        }
    }

    public void CreateRandomAd()
    {
        if (adPool.Count == 0)
        {
            FillAndShuffleAdPool(); // Reabastece e embaralha quando esgotar
        }

        int randomAd = GetNextAd();
        adPool.RemoveAt(0);

        Vector2 randomPosition = new Vector2(
            Random.Range(minBounds.x, maxBounds.x),
            Random.Range(minBounds.y, maxBounds.y)
        );

        GameObject newAdG = InstantiateAd(randomAd, randomPosition);
        if (newAdG != null)
        {
            switch (randomAd)
            {
                case 1:
                    newAdG.GetComponent<AdMController>()?.SetAntivirus(antivirus);
                    Debug.Log("M1");
                    break;
                case 2:
                    newAdG.GetComponent<AdMController>()?.SetAntivirus(antivirus);
                    Debug.Log("M2");
                    break;
                case 3:
                    newAdG.GetComponent<AdMController>()?.SetAntivirus(antivirus);
                    Debug.Log("M3");
                    break;
                case 4:
                    newAdG.GetComponent<AdPController>()?.SetAntivirus(antivirus);
                    Debug.Log("P1");
                    break;
                case 5:
                    newAdG.GetComponent<AdPController>()?.SetAntivirus(antivirus);
                    Debug.Log("P2");
                    break;
                default:
                    Debug.LogError("Invalid ad selection");
                    break;
            }
        }
    }


    private GameObject InstantiateAd(int adType, Vector2 position)
    {
        switch (adType)
        {
            case 1: return Instantiate(adM1Prefab, position, Quaternion.identity);
            case 2: return Instantiate(adM2Prefab, position, Quaternion.identity);
            case 3: return Instantiate(adM3Prefab, position, Quaternion.identity);
            case 4: return Instantiate(adP1Prefab, position, Quaternion.identity);
            case 5: return Instantiate(adP2Prefab, position, Quaternion.identity);
            default: Debug.LogError("Invalid ad selection"); return null;
        }
    }


    //----------- NOVO TBM
     public int GetNextAd()
    {
        if (adQueue.Count == 0) // Se esgotou os números, reembaralha
        {
            ShufflList(adList);
            foreach (var num in adList)
            {
                adQueue.Enqueue(num);
            }
        }

        return adQueue.Dequeue(); // Pega o próximo da fila
    }

    private void ShufflList(List<int> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            (list[i], list[j]) = (list[j], list[i]); // Swap
        }
    }

}
