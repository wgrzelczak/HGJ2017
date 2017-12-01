using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Victory : MonoBehaviour {

    public GameObject red;
    public GameObject gold;
    public FadeIn fadeIn;
    public FadeOut fadeOut;
    bool isEnd = false;

    private void Start()
    {
        AudioManager.GetInstance().ChangeBG(AUDIO.LEVEL_BG);
        red.SetActive(false);
        gold.SetActive(false);
    }

    private void Update()
    {
        if (isEnd && !fadeIn.isActive)
        {
            if (Input.anyKey)
            {
                StopAllCoroutines();
                StartCoroutine(ChangeToMenu());
                
            }
        }

    }

    public void Win(TEAM color)
    {
        isEnd = true;
        StartCoroutine(WaitForFade(color));
    }

    IEnumerator WaitForFade(TEAM color)
    {
        fadeIn.StartFadeIn();
        while (fadeIn.isActive)
        {
            yield return null;
        }
        if (color == TEAM.BLUE) gold.SetActive(true);
        else red.SetActive(true);

        fadeOut.StartFadeOut();
    }

    IEnumerator ChangeToMenu()
    {
        fadeIn.StartFadeIn();
        while (fadeIn.isActive)
        {
            yield return null;
        }
        SceneManager.LoadScene("Menu");
        AudioManager.GetInstance().ChangeBG(AUDIO.MENU_BG);
    }
}
