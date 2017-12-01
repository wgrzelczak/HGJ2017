using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperControl : MonoBehaviour {

	Animator animator;

	private Vector3 _previousDirection;
	private float _previousSignX = 1;
	private float _previousSignZ = 1;

	public float showDelay;
	private float _timer = 0.0f;


	// Use this for initialization
	void Start () {
		_previousDirection = transform.position;
		animator = GetComponent<Animator>();
		showDelay = Random.Range (3.0f, 30.0f);
		GetComponent<Renderer> ().enabled = false;
	}

	// Update is called once per frame
	void Update () {
		_timer += Time.deltaTime;

		if (_timer >= showDelay) {
			GetComponent<Renderer> ().enabled = true;
		}

		Vector3 direction = transform.position - _previousDirection;

		Vector3 std = new Vector3( 1, 0, 0 );

		float signZ = ( direction.z < 0 )? -1.0f : 1.0f;
		float signX = ( direction.x < 0 )? -1.0f : 1.0f;

		CheckAnim (Vector3.Angle (std, direction.normalized) * signZ);

		if (signX != _previousSignX) {
			Flip ();
			_previousSignX = signX;

		} else if (signZ != _previousSignZ) {
			_previousSignZ = signZ;
		}

		_previousDirection = transform.position;
	}

	void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void CheckAnim( float angle )
	{

		bool isBack = false;
		bool isFront = false;
		bool isSide = false;

		if (angle > 0 && angle <= 45) {
			isSide = true;
		} else

		if (angle > 45 && angle <= 135) {
			isBack = true;
		} else

		if (angle > 135 && angle <= 180) {
			isSide = true;
		} else

		if (angle <= 0 && angle >= -45) {
			isSide = true;
		} else

		if (angle <= -45 && angle >= -135) {
			isFront = true;
		} else

		if (angle <= -135 && angle >= -180) {
			isSide = true;
		}

		animator.SetBool ("IsTurnedBack", isBack);
		animator.SetBool ("IsTurnedFront", isFront);
		animator.SetBool ("IsTurnedSide", isSide);
	}
}
