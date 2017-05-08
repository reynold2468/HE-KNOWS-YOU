using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chase : MonoBehaviour {
	public Transform player;
	public Transform head;
	Animator anim;
	string state="patrol";
	public GameObject[] waypoints;
	int currentWP=0;
	public float rotspeed=0.2f;
	public float speed=1.5f;
	float accuracyWP=5.0f;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = player.position - this.transform.position;
		direction.z = 0;
		float angle = Vector3.Angle (direction, head.up);
		//float angle = Vector3.Angle (direction, this.transform.forward);
		if (state == "patrol" && waypoints.Length > 0) 
		{
			anim.SetBool ("IsIdle", false);
			anim.SetBool ("IsWalking", true);
			if (Vector3.Distance (waypoints [currentWP].transform.position, transform.position) < accuracyWP) 
			{ 
				currentWP++;
				if (currentWP >= waypoints.Length) 
				{
					currentWP = 0;
				}
			}
			//rotate towards waypoints
			direction=waypoints[currentWP].transform.position-transform.position;
			this.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotspeed * Time.deltaTime);
			this.transform.Translate (0, 0, Time.deltaTime * speed);
		}
		if (Vector3.Distance (player.position, this.transform.position) < 10 && (angle<30||state=="pursuing")) {
			state="pursuing";
			this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), rotspeed * Time.deltaTime);
			//direction.z = 0;
			//this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
			anim.SetBool ("IsIdle", false);
			if (direction.magnitude > 5) {
				this.transform.Translate (0, 0,Time.deltaTime*speed);
				//this.transform.Translate (0, 0, 0.05f);
				anim.SetBool ("IsWalking", true);
				anim.SetBool ("IsAttacking", false);
				anim.SetBool ("IsIdle", false);
			} 
			else {
				anim.SetBool ("IsAttacking", true);
				anim.SetBool ("IsWalking", false);
				anim.SetBool ("IsIdle", false);
			}
		} 
		else 
		{
			anim.SetBool ("IsIdle", false);
			anim.SetBool ("IsWalking", true);
			anim.SetBool ("IsAttacking", false);
			state="patrol";
		}
	}
}
