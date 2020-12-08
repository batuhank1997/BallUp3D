using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using UnityEngine.UI;

public class FacebookScript : MonoBehaviour
{
    private void Awake()
    {
        if (!FB.IsInitialized)
        {
            FB.Init(() =>
            {
                if (FB.IsInitialized)
                {
                    FB.ActivateApp();
                }
                else
                {
                    Debug.LogError("Couldn't initialize");
                }
            },
                isGameShown =>
                {
                    if (!isGameShown)
                        Time.timeScale = 0;
                    else
                        Time.timeScale = 1;
                });
        }
        else
        {
            FB.ActivateApp();
        }
    }
}
