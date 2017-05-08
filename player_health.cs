using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_health : MonoBehaviour {
	public int MaxHealth=100;
	public int Health;

	// Use this for initialization
	void Start () {
		Health = MaxHealth;	
	}
	
	// Update is called once per frame
//	void Update () {
//		
//	}
	void ApplyDamage(int damage)
	{
		Health = Health - damage;
		if (Health <= 0) {
			Dead ();
		}
	}
    void Dead ()
	{
		
		PlayerRespawn.PlayerDead = true;

	}
	void RespawnHealth()
	{
		Health = MaxHealth;	
	}
}
//#pragma strict
//var maxHealth=100;
//var Health:int;
//function Start () {
//	Health=maxHealth;
//}
//
//function ApplyDamage (theDamage:int)
//{
//	Health-=theDamage;
//	if (Health<=0)
//	{
//		Dead();
//	}
//}
//function Dead()
//{
//	PlayerRespawn.PlayerDead=true;
//
//}
//
//function RespawnHealth()
//{
//
//	Health=maxHealth;
//}
