using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class door : MonoBehaviour {
	public Transform player;
	public Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = player.position - this.transform.position;
		if (Vector3.Distance (player.position, this.transform.position) < 5) 
		{
			anim.SetBool ("IsOpen", true);
			anim.SetBool ("IsClose", false);
		}
	}
}
