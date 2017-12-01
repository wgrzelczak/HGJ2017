using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AUDIO
{
    MENU_BG,
    LEVEL_BG,
    ITEM_SPAWN,
    ITEM_COLLECT,
    CAT_SPAWN,
    CAT_COLLECT,
    DOORS_CRASH
}


public class AudioManager : MonoBehaviour {

    public AudioClip menuBg;
    public AudioClip levelBg;

    public AudioSource itemSpawn;
    public AudioSource itemCollecting;
    public AudioSource catSpawn;
    public AudioSource catCollecting;
    public AudioSource doorsCrash;


    AudioSource src;

    private static AudioManager instance = null;

    public void Awake()
    {
        instance = this;
    }

    public static AudioManager GetInstance()
    {
        return instance;
    }

    void Start () {
        DontDestroyOnLoad(this);
        src = GetComponent<AudioSource>();

        src.clip = menuBg;
        src.Play();
	}

    public void ChangeBG(AUDIO audio)
    {
        switch (audio)
        {
            case AUDIO.MENU_BG:
                src.clip = menuBg;
                break;
            case AUDIO.LEVEL_BG:
                src.clip = levelBg;
                break;
        }
        src.Play();
    }

    public void PlaySFX(AUDIO audio)
    {
        switch (audio)
        {
            case AUDIO.MENU_BG:
                break;
            case AUDIO.LEVEL_BG:
                break;
            case AUDIO.ITEM_SPAWN:
                itemSpawn.Play();
                break;
            case AUDIO.ITEM_COLLECT:
                itemCollecting.Play();
                break;
            case AUDIO.CAT_SPAWN:
                catSpawn.Play();
                break;
            case AUDIO.CAT_COLLECT:
                catCollecting.Play();
                break;
            case AUDIO.DOORS_CRASH:
                doorsCrash.Play();
                break;
        }

    }
}