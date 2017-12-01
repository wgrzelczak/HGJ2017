using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public float shakeValue = 0.2f;
    float shake = 0.2f;
    float shakeAmount = 0.4f;
    float decreaseFactor;
    float decreaseFactorHolder = .8f;

    Vector3 orgPos;

    private void Start()
    {
        orgPos = transform.position;
        shakeValue = .8f;
        StartCoroutine(Shake());
        shakeValue = 0.2f;
        decreaseFactorHolder = 1.0f;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
        {
            StopAllCoroutines();
            StartCoroutine(Shake());
        }
    }

    public IEnumerator Shake()
    {
        shake = shakeValue;
        decreaseFactor = decreaseFactorHolder;
        while (shake > 0)
        {
            Vector3 newPos = Random.insideUnitSphere * shakeAmount;
            newPos.y = orgPos.y;
            transform.localPosition = newPos;
            shake -= Time.deltaTime * decreaseFactor;
            yield return null;
        }
        int i = 1000;
        while(i > 0)
        {
            transform.localPosition = Vector3.Lerp(transform.localPosition, orgPos, --i);
            yield return null;
        }
    }
}
