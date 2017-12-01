using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOut : MonoBehaviour
{
    public float FadeInTime = 0.68f;
	public float FadeInDelay = 2.0f;

    private float _fadeInTimer = 0.0f;

    float tmpTimer = 0.0f;
    private void Start()
    {
        StartCoroutine(Activate());
    }

    public void StartFadeOut()
    {
        StopAllCoroutines();
        _fadeInTimer = tmpTimer;
        GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
        StartCoroutine(Activate());
    }

    // Update is called once per frame
    IEnumerator Activate()
    {
		while (_fadeInTimer <= FadeInTime + FadeInDelay )
        {
            _fadeInTimer += Time.deltaTime;

			if (_fadeInTimer >= FadeInDelay)
			{
				Color tmp = GetComponent<SpriteRenderer>().color;
				tmp.a = 1 - ( _fadeInTimer - FadeInDelay ) / FadeInTime;

				GetComponent<SpriteRenderer>().color = tmp;
			}
				
            yield return null;
        }
    }
}
