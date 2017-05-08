using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {
	public GameObject playerlook;
	public GameObject charController;
	public Transform respawntransform;
	public static bool PlayerDead = false;

	// Use this for initialization
	public void Start () {
		if (PlayerDead == true) 
		{
			if (GUI.Button (new Rect (10, 80, 100, 20), "Respawn")) 
			{
				RespawnPlayer ();

			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerDead == true) 
		{
			playerlook.SetActive(false);
			charController.SetActive(false);
		}
	}
	void OnGUI()
	{
		
	}
	void RespawnPlayer()
	{
		transform.position = respawntransform.position;
		transform.rotation = respawntransform.rotation;
		gameObject.SendMessage("RespawnHealth");
		playerlook.SetActive(true);
		charController.SetActive(true);
		PlayerDead=false;
	}
}
////var playerLook: UnityStandardAssets.Characters.FirstPerson.FirstPersonController;
////var charController:CharacterController;
////var respawnTransform:Transform;
////static var PlayerDead=false;
////function Start () {
////	playerLook=gameObject.GetComponent(UnityStandardAssets.Characters.FirstPerson.FirstPersonController);
////	charController=gameObject.GetComponent(CharacterController);
////}
////
////function Update () {
////	if (PlayerDead==true)
////	{
////		playerLook.enabled=false;
////		charController.enabled=false;
////
////	}
////}
////function OnGUI()
////{
////	if(PlayerDead==true)
////	{
////		GUI.Box(Rect(Screen.width*0.5-50,200-20,100,40),"You Died");
////		if (GUI.Button(Rect(Screen.width*0.5-50,240,100,40),"Respawn"))
////		{
////			RespawnPlayer();
////		}
////	}
////}
////function RespawnPlayer()
////{
////	transform.position=respawnTransform.position;
////	transform.rotation=respawnTransform.rotation;
////	gameObject.SendMessage("RespawnHealth");
////	playerLook.enabled=true;
////	charController.enabled=true;
////	PlayerDead=false;
////
////}