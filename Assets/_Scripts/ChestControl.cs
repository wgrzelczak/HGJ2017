using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestControl : MonoBehaviour {

	public Animator animator = null;
	public ParticleSystem particles = null;

	public Color ColorA;
	public Color ColorB;

	private bool _consumed = false;

	// Use this for initialization
	void Start () {
		animator = GetComponent<Animator> ();
		particles = GetComponent<ParticleSystem> ();
		particles.Stop ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter( Collision collision )
	{
		if ( !_consumed && collision.gameObject.tag == "Playerr")
		{
			animator.SetTrigger ("OpenChest");

			var team = collision.gameObject.GetComponent<Player> ().team;

			var main = particles.main;
			main.startColor = ( team == TEAM.RED ) ? ColorA : ColorB;

			particles.Play ();
            FindObjectOfType<Victory>().Win(collision.gameObject.GetComponent<Player>().team);
			_consumed = true;
		}
	}


}
