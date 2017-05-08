#pragma strict
var maxHealth=100;
var Health:int;
function Start () {
	Health=maxHealth;
}

function ApplyDamage (theDamage:int)
{
	Health-=theDamage;
	if (Health<=0)
		{
			Dead();
		}
}
function Dead()
{
	PlayerRespawn.PlayerDead=true;

}

function RespawnHealth()
{

	Health=maxHealth;
}
