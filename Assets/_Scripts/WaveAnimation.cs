using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveAnimation : MonoBehaviour {

    [SerializeField] Vector2 _speed;
    Material _material;
    float alpha = 0.5f;
    private void Start()
    {
        _material = GetComponent<Renderer>().material;
        _material.mainTextureOffset = new Vector2(-1f, 0f);
        _material.SetColor("_Albedo", new Color(0, 0, 0, 100));
        _material.SetFloat("_Cutoff", alpha);
    }

    private void Update()
    {
        _material.mainTextureOffset += _speed * Time.deltaTime;

        if(_material.mainTextureOffset.x > 0.9f)
        {
            Destroy(gameObject);
        }
    }
}
