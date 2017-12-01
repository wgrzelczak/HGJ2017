using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Doors : MonoBehaviour
{
    public int hp = 100;
    public TEAM team;
    public bool areDestroyed = false;
    public GameObject gfx;
    public HealthBar healthBar;
	private int startHp = 0;

	private void Start()
	{
		startHp = hp;
		gfx.GetComponent<ParticleSystem> ().Stop ();
	}

    private void Update()
    {
        if(!areDestroyed && hp <= 0)
        {
            print("doors destroyed");
            areDestroyed = true;
            gfx.SetActive(false);
            AudioManager.GetInstance().PlaySFX(AUDIO.DOORS_CRASH);
            GetComponent<Collider>().enabled = false;
            GetComponent<MeshRenderer>().enabled = false;
            StopAllCoroutines();
            StartCoroutine(Camera.main.GetComponent<CameraShake>().Shake());
        }
    }

    public void Hit(int damage)
    {
        //print(name);
        hp -= damage;
		gfx.GetComponent<ParticleSystem> ().Emit (1);
        healthBar.SetValue(hp, startHp);
    }
}
