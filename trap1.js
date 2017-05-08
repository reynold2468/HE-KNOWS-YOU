#pragma strict
var Distance;
var attackrange=2.0;
var trap: GameObject;
var target:Transform;
var theDamage=70;
var charController1:CharacterController;
function Start () {
	trap.SetActive(false);
}
function Visible()
{
	trap.SetActive(true);
}
function Update () {
	if (trap.SetActive==true)
	{
//		Distance=Vector3.Distance(target.position,transform.position);
//		if (Distance<=attackrange)
//		{
//			harmPlayer();
//		}
	}

}
function harmPlayer()
	{
		target.SendMessage ("ApplyDamage", theDamage);
	}
