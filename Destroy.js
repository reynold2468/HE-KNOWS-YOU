var loghealth:int =50;
static var destroyed=false;
var destroyed_log :GameObject; 
function DeductPoints(hitpoints:int)
{
loghealth-=hitpoints;
}

function Update () {
	if(loghealth<=0)
	{
		destroyed=true;
		destroyed_log.SetActive(false);
	}
}
