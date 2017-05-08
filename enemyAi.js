var Distance;
var Target:Transform;
var attackrange=2.0;
var theDamage=40;
private var attackTime:float;
var attackRepeatTime=1;
var controller:CharacterController;

function Start () {
	attckTime=Time.time;
}

function Update () {
	Distance=Vector3.Distance(Target.position,transform.position);
	if(Distance<=attackrange)
	{
	AttackPlayer();
	}
}
function AttackPlayer()
{
if(Time.time>attackTime)
{
Target.SendMessage("ApplyDamage",theDamage);
attackTime=Time.time+attackRepeatTime;
}
}