using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

public class theboss_chasingsc : MonoBehaviour {

	public NavMeshAgent agent;
	public ThirdPersonCharacter character;

	public Transform player;
	public Transform head;

	private Animator anim;
//	string state="patrol";
	public GameObject[] waypoints;
	private int currentWP;
	public float rotspeed=0.9f;
	public float speed=1.5f;
	float accuracyWP=1.5f;
	public bool ranbool = true;
	public bool stop = true;
	float wait_time;
	public float waypoint_waittime;
	public GameObject target;
	GameObject logtrap;
	public enum State
	{
		PATROL,
		CHASE,
		ATTACK
	}
	public State state1;
	private bool alive;
	/// <summary>
	//Varaibles for patrolling


	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		character = GetComponent<ThirdPersonCharacter> ();
		agent.updatePosition = true;
		agent.updateRotation = false;
		state1 = theboss_chasingsc.State.PATROL;
		alive = true;
		StartCoroutine ("FSM");
		anim = GetComponent<Animator> ();
	}
	IEnumerator FSM()
	{
		while (alive) {
			switch (state1) 
			{
				case State.PATROL:
					patrol ();
					break;
				case State.CHASE:
					Pursue ();
					break;
				case State.ATTACK:
					attack ();
					break;
			}
			yield return null;

		}
	}
	// Update is called once per frame
	void Update () {
//		wait_time += Time.deltaTime;
//		Debug.Log (wait_time);
//		//Pursue ();
//		if(ranbool){
//			patrol();
//
//		}
//			
//		if (wait_time > waypoint_waittime) {
//			patrol();
//		}	
//		if (Vector3.Distance (this.transform.position, target.transform.position) <7) {
//			state1 = theboss_cshasingsc.State.CHASE;
//			}
//		if (Vector3.Distance (this.transform.position, target.transform.position) <=2) {
//			
//			state1 = theboss_chasingsc.State.ATTACK;
//		}
		if (Vector3.Distance (this.transform.position, target.transform.position) >10) {
			
			state1 = theboss_chasingsc.State.PATROL;
		}




		//float angle = Vector3.Angle (direction, this.transform.forward);

	}





	void patrol ()
		{	
		
			agent.speed = speed;
		if (Vector3.Distance (this.transform.position, waypoints [currentWP].transform.position) >= accuracyWP) {
					agent.SetDestination (waypoints [currentWP].transform.position);
					character.Move (agent.desiredVelocity, false, false);
					//anim.SetBool ("Is_Walking", true);

				} else if (Vector3.Distance (this.transform.position, waypoints [currentWP].transform.position) <=2) {
					currentWP++;
					if (currentWP >= waypoints.Length) {
						currentWP = 0;
			
					}
		
			} 
			else {
					character.Move (Vector3.zero, false, false);
				}
			

		





////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	//	state="patrol";

		Vector3 direction = player.position - this.transform.position;
		direction.z = 0;
		float angle = Vector3.Angle (direction, head.up);
//		agent.speed = speed;
//		if (state == "patrol" && waypoints.Length > 0) {
//			anim.SetBool ("Is_Idle", false);
//			anim.SetBool ("Is_Walking", true);
//			//print("The variable is :"+this.transform.position);
//			if (Vector3.Distance (waypoints [currentWP].transform.position, transform.position) < accuracyWP) { 
//				
//				currentWP++;
//				if (currentWP >= waypoints.Length) {
//					currentWP = 0;
//				}
//			}
//			direction = waypoints [currentWP].transform.position - transform.position;
//			this.transform.rotation = Quaternion.Slerp (transform.rotation, Quaternion.LookRotation (direction), rotspeed * Time.deltaTime);
//			this.transform.Translate (0, 0, Time.deltaTime * speed);

			//if(stop){
//			if (stop) {
//				StopAt3 ();
//				StopAt7 ();
//
//			}
//			if (Vector3.Distance (waypoints [3].transform.position, transform.position) < 1) {
//				stop = true;
//			} 
//
//
//
//		}
////	}
//	void StopAt3(){
//		if (Vector3.Distance (waypoints [2].transform.position, transform.position) < 1 || state=="Idle") {
//			state="Idle";
//			wait_time = 0;
//
//
//			//state="idle";
//
//			anim.SetBool ("Is_Walking", false);
//			anim.SetBool ("Is_Idle", true);
//
//			Pursue ();
//			ranbool = false;
//			stop = false;
//		}
//	}
//	void StopAt7(){
//		if (Vector3.Distance (waypoints [7].transform.position, transform.position) < 1 || state=="Idle") {
//			state="Idle";
//			wait_time = 0;
//
//
//			//state="idle";
//
//			anim.SetBool ("Is_Walking", false);
//			anim.SetBool ("Is_Idle", true);
//
//
//			ranbool = false;
//			stop = false;
//		}
//	
	}
	void Pursue(){
		
		agent.speed = speed*2;
		agent.SetDestination (target.transform.position);
		character.Move2 (agent.desiredVelocity, false, false);







/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
//			Vector3 direction = player.position - this.transform.position;
//			float angle = Vector3.Angle (direction, head.up);
//			direction.z = 0;
//			if (Vector3.Distance (player.position, this.transform.position) < 10 && (angle<30||state=="pursuing")) {
//				state="pursuing";
//				var lookPos = player.position - this.transform.position;
//				lookPos.y = 0;
//				var rotation = Quaternion.LookRotation(lookPos);
//				this.transform.rotation = Quaternion.Slerp(this.transform.rotation, rotation, Time.deltaTime * rotspeed);
//				//this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), rotspeed * Time.deltaTime);
//				//direction.z = 0;
//				//this.transform.rotation = Quaternion.Slerp (this.transform.rotation, Quaternion.LookRotation (direction), 0.1f);
//				anim.SetBool ("Is_Idle", false);
//				if (direction.magnitude > 5) {
//					this.transform.Translate (0, 0,Time.deltaTime*speed);
//					//this.transform.Translate (0, 0, 0.05f);
//					anim.SetBool ("Is_Walking", false);
//					anim.SetBool ("Is_Running", true);
//					anim.SetBool ("Is_Idle", false);
//					anim.SetBool ("Is_Attacking", false);
//				} 
//				else {
//					anim.SetBool ("Is_Attacking", true);
//					anim.SetBool ("Is_Walking", false);
//					anim.SetBool ("Is_Idle", false);
//					anim.SetBool ("Is_Running", false);
//
//
//				}
//			} 
//			else 
//			{
//				//			anim.SetBool ("Is_Attacking", false);
//				//			anim.SetBool ("Is_Idle", false);
//				//			anim.SetBool ("Is_Walking",true);
//				//			anim.SetBool ("Is_Running",false);
//				//			state="patrol";
//				//patrolTill3();
//			}

	}
	void attack(){
		agent.speed = speed;
		agent.SetDestination (target.transform.position);
		character.Move3 (agent.desiredVelocity, false, false);

	
	}
	void OnTriggerEnter(Collider coll)
	{
		
		if (coll.tag == "Player") {
			state1 = theboss_chasingsc.State.CHASE;
			target = coll.gameObject;

		}
		if (Vector3.Distance (this.transform.position, target.transform.position) <= 2) {
			state1 = theboss_chasingsc.State.ATTACK;
		}

	}
//	void OnTriggerExit(Collider coll)
//	{
//		if (coll.tag == "Player") {
//			
//			state1 = theboss_chasingsc.State.PATROL;
//
//		}
//	}

}
