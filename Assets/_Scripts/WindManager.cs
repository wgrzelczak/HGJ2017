using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindManager : MonoBehaviour {

    public GameObject prefab;
    public float delayInSec;
    public Transform[] positions;

    private void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while(true)
        {
            int n = Random.Range(0, positions.Length);
            Instantiate(prefab, positions[n].position, prefab.transform.rotation);

            yield return new WaitForSeconds(delayInSec);
        }
    }
}
