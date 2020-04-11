using System.Collections;
using UnityEngine;
using UnityEngine.Advertisements;

public class Monetization : MonoBehaviour
{
    public string gameId = "3465076";
    public string placementId = "Banerr";
    public bool testMode = true;

    void Start()
    {

        Advertisement.Initialize(gameId, testMode);
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
        StartCoroutine(ShowBannerWhenReady());
    }

    IEnumerator ShowBannerWhenReady()
    {
        while (!Advertisement.IsReady(placementId))
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.Show(placementId);
    }

}
