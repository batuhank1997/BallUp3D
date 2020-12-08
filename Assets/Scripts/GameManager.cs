using GameAnalyticsSDK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    public bool playAds;

    public bool gameStart = false;
    public bool gameOver = false;
    public bool gameFinish = false;
    public bool shootRegion = false;

    public GameObject tapToStartObj;
    public GameObject finishObj;
    public GameObject gameOverObj;
    public GameObject levelNumObj;
    public GameObject player;

    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public int blueBoxes = 0;

    private void Awake()
    {
        II = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        playAds = false;
        GameAnalytics.Initialize();
        PlayerPrefs.SetInt("HighScore", blueBoxes);
        levelNumObj.SetActive(true);
        StartCoroutine(Wait2());
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void NextLevel()
    {
        if(SceneManager.GetActiveScene().buildIndex == 3 || SceneManager.GetActiveScene().buildIndex == 6 || SceneManager.GetActiveScene().buildIndex == 8 || SceneManager.GetActiveScene().buildIndex == 10)
        {
            playAds = true;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Update is called once per frame
    void Update()
    {
        PlayerPrefs.SetInt("HighScore", blueBoxes);

        if (Input.GetMouseButtonDown(0))
        {
            gameStart = true;
            tapToStartObj.SetActive(false);
        }
        if(gameOver == true)
        {
            GameOver();
        }
        if (gameFinish == true)
        {
            Finish();
        }
    }
    void GameOver()
    {
        StartCoroutine(Wait());
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(0.5f);
        gameOverObj.SetActive(true);
    }
    IEnumerator Wait2()
    {
        yield return new WaitForSeconds(1);
        levelNumObj.SetActive(false);
    }
    public void Finish()
    {
        finishObj.SetActive(true);

        if (blueBoxes > 0 && blueBoxes <= 20)
        {
            star1.SetActive(true);
        }

        if (blueBoxes > 20 && blueBoxes <= 40)
        {
            star1.SetActive(true);
            star2.SetActive(true);
        }

        if (blueBoxes >= 40)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }

    }

    public static GameManager II;
    public static GameManager I
    {
        get
        {
            if (II == null)
            {
                II = GameObject.Find("GameManager").GetComponent<GameManager>();
            }
            return II;
        }
    }

}
