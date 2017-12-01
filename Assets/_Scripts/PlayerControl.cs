using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

	public float _velocity = 1.0f;
    public string _padName;
    Rigidbody rb;
    Player player;
	Animator animator;
	private Dictionary<string, GameObject> _helpers = null;

	private float _previousSignZ;
	private float _previousSignX;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        player = GetComponent<Player>();
		animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update () 
	{
        Vector3 direction = new Vector3(Input.GetAxis("H_" + _padName) + Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("V_"+_padName) + Input.GetAxis("Vertical"));

        rb.AddForce(direction.normalized * _velocity * Time.deltaTime, ForceMode.Impulse);

        if (Input.GetButtonDown("A_" + _padName) || Input.GetKeyDown(KeyCode.Space))
        {
            player.Action(ACTION.SKILL_1);
        }

        if (Input.GetButtonDown("B_" + _padName))
        {
            player.Action(ACTION.SKILL_2);
        }

		Vector3 std = new Vector3( 1, 0, 0 );

		float signZ = ( direction.z < 0 )? -1.0f : 1.0f;
		float signX = (direction.x < 0) ? -1.0f : 1.0f;

		CheckAnim (Vector3.Angle (std, direction.normalized) * signZ);

		if (signX != _previousSignX) {
			Flip ();
			_previousSignX = signX;

		} else if (signZ != _previousSignZ) {
			_previousSignZ = signZ;
		}
	}

	void Flip()
	{
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void OnCollisionEnter( Collision collision )
	{
		if (collision.gameObject.tag == "helper")
		{
			Consume( collision.gameObject );
		}
	}


	void Consume( GameObject other )
	{
		// add helper to protagonist
		_helpers.Add( other.name, other );
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
