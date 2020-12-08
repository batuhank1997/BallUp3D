using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    string placement = "rewardedVideo";
    private string appStoreID = "3911066";

    IEnumerator Start()
    {
        Advertisement.AddListener(this);

        if (GameManager.I.playAds == true)
        {
            Advertisement.Initialize(appStoreID, true);

            while (!Advertisement.IsReady())
                yield return null;

            Advertisement.Show();
        }
    }
    public void PlayAds()
    {
        Advertisement.Initialize(appStoreID, true);

        /*while (!Advertisement.IsReady(placement))
            yield return null;*/

        Advertisement.Show(placement);
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log(message);
    }

    public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
    {
        if(showResult == ShowResult.Finished)
        {
            GameManager.I.blueBoxes = 50;
            GameManager.I.NextLevel();
        } else if (showResult == ShowResult.Failed)
        {
            Debug.Log("Ads playing failed!");
            //Debug.Log(showResult);
        }
    }

    public void OnUnityAdsDidStart(string placementId)
    {

    }

    public void OnUnityAdsReady(string placementId)
    {/*
        if (placementId == placement)
        {
            Advertisement.Show(placement);
        }*/
    }

}
