using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorHolder : MonoBehaviour {
	private Animator _anim = null;
	// Use this for initialization
	void Start () {
		_anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter(Collider collider)
	{
		_anim.SetBool ("IsOpen", true);
	}
	void OnTriggerExit(Collider collider)
	{
		_anim.SetBool ("IsOpen", false);

	}
}
