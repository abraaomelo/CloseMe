using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AdSpawner : MonoBehaviour
{
    private List<int> adPool = new List<int>();
    public GameObject adM1Prefab, adM2Prefab, adM3Prefab, adP1Prefab, adP2Prefab;
    public Vector2 minBounds, maxBounds;
    public AntivirusApp antivirus;

    private void Start()
    {
        FillAndShuffleAdPool();
    }

    public void SpawnAd()
    {
        if (adPool.Count == 0)
        {
            FillAndShuffleAdPool();
        }

        int randomAd = adPool[0];
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
                    break;
                case 2:
                    newAdG.GetComponent<AdMController>()?.SetAntivirus(antivirus);
                    break;
                case 3:
                    newAdG.GetComponent<AdMController>()?.SetAntivirus(antivirus);
                    break;
                case 4:
                    newAdG.GetComponent<AdPController>()?.SetAntivirus(antivirus);
                    break;
                case 5:
                    newAdG.GetComponent<AdPController>()?.SetAntivirus(antivirus);
                    break;
                default:
                    Debug.LogError("Invalid ad selection");
                    break;
            }
        }
    }

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
            (list[i], list[j]) = (list[j], list[i]);
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
}
