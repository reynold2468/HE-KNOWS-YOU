#pragma strict
var Distance;
var attackrange=2.0;
var logtrap: GameObject;
var target:Transform;
var theDamage=70;
var charController1:CharacterController;
var LockSecondTrap:int=0;
function Start () {
	logtrap.SetActive(false);
}
function Visible1()
{
	
	logtrap.SetActive(true);

}

//function harmPlayer()
//	{
//		target.SendMessage ("ApplyDamage", theDamage);
//	}
