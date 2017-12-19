using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Character : MonoBehaviour {

	//protected Animator myAnim;
	[SerializeField]
	protected Transform BulletPos;

	[SerializeField]
	private GameObject BulletPrefab;

	protected bool FacingR;

	[SerializeField]
	protected float MovSpeed;

	public bool Attack {get; set;}

	public Animator MyAnimator { get; set;}

	// Use this for initialization
	public virtual void Start () {
		//Debug.Log ("CharStart");
		FacingR = true;
		MyAnimator = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {

	}

	public void changeDir()
	{
		FacingR = !FacingR;
		transform.localScale = new Vector3 (transform.localScale.x * -1, 1, 1);
	}

	public void ShootBull(int value)
	{
		if (FacingR) {
			GameObject tmp = (GameObject)Instantiate (BulletPrefab, BulletPos.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			tmp.GetComponent<Bullet> ().Initialize (Vector2.right);
		} 
		else 
		{
			GameObject tmp = (GameObject)Instantiate (BulletPrefab, BulletPos.position, Quaternion.Euler (new Vector3 (0, 0, 0)));
			tmp.GetComponent<Bullet> ().Initialize (Vector2.left);
		}
	}

}
