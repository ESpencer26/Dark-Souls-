using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CameraMov : MonoBehaviour {

	public Vector3 MovS;
	public float Del;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.time > Del) {
			transform.position += MovS;
		}
	}

}
