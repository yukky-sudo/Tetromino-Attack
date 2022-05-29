using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class Ads : MonoBehaviour
{
    public bool is_enable = true;
    public string gameId = "4666492";
    public string bannerId = "Banner_Android";
    public bool testMode = true;
    void Start()
    {
        int volume = PlayerPrefs.GetInt("abs", 0);
        if (volume == 1)
        {
            is_enable = false;
        }

        if (is_enable)
        {
            Advertisement.Initialize(gameId, testMode);
            StartCoroutine(showBanner());
        }
    }
    IEnumerator showBanner()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.3f); // 0.3秒後に広告表示
        }
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER); //バナーを上部中央にセット
        Advertisement.Banner.Show(bannerId);
    }
    public void Disable()
    {
        PlayerPrefs.SetInt("ads", 1);
        PlayerPrefs.Save();
    }
}
