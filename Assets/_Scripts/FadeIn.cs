using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {

	public float FadeInTime = 0.68f;
	public float FadeInDelay = 2.0f;

	private float _fadeInTimer = 0.0f;
    float tmp = 0.0f;
    public bool isActive = false;

    public void StartFadeIn()
    {
        _fadeInTimer = tmp;
        StopAllCoroutines();
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
        StartCoroutine(Activate());
    }

    IEnumerator Activate()
    {
        isActive = true;
		while(_fadeInTimer <= FadeInTime + FadeInDelay )
        {
            _fadeInTimer += Time.deltaTime;

			if (_fadeInTimer >= FadeInDelay)
			{
				Color tmp = GetComponent<SpriteRenderer>().color;
				tmp.a = ( _fadeInTimer - FadeInDelay ) / FadeInTime;
				GetComponent<SpriteRenderer>().color = tmp;
			}

            yield return null;
        }
        isActive = false;
    }
}
