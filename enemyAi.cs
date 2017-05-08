

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAi : MonoBehaviour {
	float distance;
	public Transform target;
	public float attackrange=2;
	public float damage=40;
	private float AttackTime;
	int AttackRepeatTime=1;
	public CharacterController character;


	// Use this for initialization
	void Start () {
		AttackTime = Time.time;
		//ph = GameObject.Find ("FPSController").GetComponent<player_health> ();


	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (target.position, this.transform.position);
		if (distance <= attackrange) 
		{
			AttackPlayer ();
		}
	}
	void AttackPlayer()
	{
		
		if (Time.time > AttackTime) 
		{
			//ph.ApplyDamage (40);
			target.BroadcastMessage ("ApplyDamage", damage);
			AttackTime = Time.time + AttackRepeatTime;

		}	
	}
}
