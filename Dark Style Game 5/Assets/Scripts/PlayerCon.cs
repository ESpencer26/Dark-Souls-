using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCon : Character {

	private static PlayerCon instance;

	public static PlayerCon Instance {
		get { 
			if (instance == null) 
			{
				instance = GameObject.FindObjectOfType<PlayerCon> ();
			}
			return instance;
		}
}

	//private Animator myAnim;

	//[SerializeField]
	//private Transform BulletPos

	//[SerializeField]
	//private float MovSpeed;

	//private bool FacingR;

	[SerializeField]
	private Transform[] groundP;

	[SerializeField]
	private float groundRad;

	[SerializeField]
	private LayerMask WhatIsGround;

	[SerializeField]
	private bool airCon;

	[SerializeField]
	private float JumpFor;

	public Rigidbody2D MyRigidbody {get; set;}

	//public bool Attack {get; set;}

	public bool Slide {get; set;}

	public bool Jump {get; set;}

	public bool OnGround {get; set;}

	private Vector2 startPos;


	// Use this for initialization
	public override void Start () 
	{
		//Debug.Log ("PlayerStart");
		base.Start();
		//sFacingR = true; 
		startPos = transform.position;
		MyRigidbody = GetComponent<Rigidbody2D>();
		//myAnim = GetComponent<Animator> ();
	}

	void Update()
	{
		HandInput();
	}

	void FixedUpdate () 
	{
		float horizontal = Input.GetAxis ("Horizontal");

		OnGround = IsGrounded();

		HandleMov(horizontal);

		Flip(horizontal);
	}

	private void HandleMov(float horizontal)
	{
		if (MyRigidbody.velocity.y < 0) 
		{
			//myAnim.SetBool ("land", true);
		}
		if (!Attack && !Slide && (OnGround || airCon))
		{
			MyRigidbody.velocity = new Vector2 (horizontal * MovSpeed, MyRigidbody.velocity.y);
		}
		if (Jump && MyRigidbody.velocity.y == 0)
		{
			MyRigidbody.AddForce (new Vector2 (0, JumpFor));
		}
		MyAnimator.SetFloat ("speed", Mathf.Abs (horizontal));
	}

	private void HandInput()
	{
		if(Input.GetKeyDown(KeyCode.I))
		{
			MyAnimator.SetTrigger ("Attack");
		}

		if (Input.GetKeyDown (KeyCode.U)) 
		{
			MyAnimator.SetTrigger("slide");
		}

		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			MyAnimator.SetTrigger ("jump");
		}
			
	}

	private void Flip(float horizonal)
	{
		if (horizonal > 0 && !FacingR || horizonal < 0 && FacingR) 
		{
			changeDir();
		}
	}
		
	private bool IsGrounded()
	{
		if (MyRigidbody.velocity.y <= 0) 
		{
			foreach (Transform point in groundP) 
			{
				Collider2D[] colliders = Physics2D.OverlapCircleAll (point.position, groundRad, WhatIsGround);
				for (int i = 0; i < colliders.Length; i++)
				{
					if (colliders[i].gameObject != gameObject)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		if(other.gameObject.tag == "Mag")
		{
			Destroy (other.gameObject);
		}
	}
}
