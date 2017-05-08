//#pragma strict
import System.Xml; 
import System.Xml.Serialization;
var playerLook: UnityStandardAssets.Characters.FirstPerson.FirstPersonController;
var charController:CharacterController;
var respawnTransform:Transform;
var trap: GameObject;
static var PlayerDead=false;
public var SaveStatistics;
public var b:int=0;
var traptarget:Transform;
var dinningTrap:Transform;
var logtrap:GameObject;
var restroomTrapobject:GameObject;
var logtraptarget:Transform;
var restroomTrap:Transform;

var firsttime:int;
function Start () {
	playerLook=gameObject.GetComponent(UnityStandardAssets.Characters.FirstPerson.FirstPersonController);
	charController=gameObject.GetComponent(CharacterController);
    
}

function Update () {
	if (PlayerDead==true)
	{
		playerLook.enabled=false;
		charController.enabled=false;

	}
}
function OnGUI()
{
 	if(PlayerDead==true)
 	{
 		GUI.Box(Rect(Screen.width*0.5-50,200-20,100,40),"You Died");
 		if (GUI.Button(Rect(Screen.width*0.5-50,240,100,40),"Respawn"))
 		{
 			RespawnPlayer();
 			b++;
     		Loaddata();

			
 		}
 	}

//	if (GUI.Button (new Rect (100, 150, 50, 60), "Start")) {
//			SaveStatistics.PrepareLog ();
//			
//	}
}
function RespawnPlayer()
{
transform.position=respawnTransform.position;
transform.rotation=respawnTransform.rotation;
gameObject.SendMessage("RespawnHealth");
playerLook.enabled=true;
charController.enabled=true;
PlayerDead=false;

}
function range( x,minrange,maxrange)
{
return x>=minrange && x<=maxrange;
}
function Loaddata()
{
	

	
	var doc : XmlDocument = new XmlDocument();

	doc.Load(Application.dataPath + "/" + "log"+b+".xml") ;
    
    var root : XmlNode = doc.DocumentElement;
    Debug.Log( root.Name );
   
    var nodeList : XmlNodeList; 
    nodeList = root.SelectNodes( "location" );  
   
    nodeList = nodeList[0].ChildNodes;  
    Debug.Log( nodeList.Count ); 
   
   
    // loop through each of MyObjects
    for ( var i : int = 0; i < nodeList.Count; i ++ )
    {	
    	
    	var node = nodeList[i];
    	Debug.Log( nodeList[i].Attributes["runningTime"].Value ); 
        Debug.Log(nodeList[i].ChildNodes[0].InnerText);
        Debug.Log(nodeList[i].ChildNodes[1].InnerText);
        Debug.Log(nodeList[i].ChildNodes[2].InnerText);
        var x=nodeList[i].ChildNodes[0].InnerText;
        var y=nodeList[i].ChildNodes[1].InnerText;
        var z=nodeList[i].ChildNodes[2].InnerText; 
        var my_x = parseInt(x);
        var my_z = parseInt(z);
        if (my_z>=17 && my_z<=20 && my_x>=48 && my_x<=54)
        {
        	
        		
         		traptarget.BroadcastMessage("Visible");

        }
        if(my_x>=30 && my_x<=35 && my_z>=40	&& my_z<=45)
        {
        	Debug.Log("Success");

        	logtraptarget.BroadcastMessage("Visible1");

        	dinningTrap.BroadcastMessage("Visible");
        	

        }
        if(my_x>=58 && my_x<=62 && my_z>=50	&& my_z<=55){
        	restroomTrap.BroadcastMessage("Visible1");
        }



        //Debug.Log( nodeList[i].Attributes.Element["Health"].Value ); // MySubElement1
        //Debug.Log( nodeList[i].Attributes.Element["Attack"].Value ); // MySubElement2
        //Debug.Log( nodeList[i].Attributes.Element["Defense"].Value ); // MySubElement3
    }
   
}



//var node = nodeList[i];
//    Debug.Log(node.Attributes["name"].Value );
// 
//    Debug.Log(node.SelectSingleNode("Health").InnerText);
/////////////////////////////////////////////////////////////////////////////
//var fs : FileStream = new FileStream(pathToFile, FileMode.Open);
//var s : XmlSerializer = new XmlSerializer(typeof(MonsterCollection));
//var collection : MonsterCollection;
//collection = s.Deserialize(fs) as MonsterCollection;
//fs.Dispose();
//for (monster in collection.monsters)
//{
//    Debug.Log(monster.name);
//    Debug.Log(monster.health);
//    Debug.Log(monster.attack);
//    Debug.Log(monster.defense);
//}
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using System.Xml.Linq;
//using UnityEngine;
//
//public class ParseXML : MonoBehaviour {
//
//	// Use this for initialization
//	void Start () {
//
//        List<Dictionary<string, string>> allTextDic = parseFile();
//        Dictionary<string, string> dic = allTextDic[0];
//        Debug.Log(dic["riddle"]);
//        Debug.Log(dic["ans"]);
//
//    }
//
//    public List<Dictionary<string, string>> parseFile()
//    {
//        TextAsset txtXmlAsset = Resources.Load<TextAsset>("riddles");
//        var doc = XDocument.Parse(txtXmlAsset.text);
//
//        var allDict = doc.Element("document").Elements("row");
//        List<Dictionary<string, string>> allTextDic = new List<Dictionary<string, string>>();
//        foreach (var oneDict in allDict)
//        {
//            var twoStrings = oneDict.Elements("string");
//            XElement element1 = twoStrings.ElementAt(0);
//            XElement element2 = twoStrings.ElementAt(1);
//            string first = element1.ToString().Replace("<string>", "").Replace("</string>", "");
//            string second = element2.ToString().Replace("<string>", "").Replace("</string>", "");
//
//            Dictionary<string, string> dic = new Dictionary<string, string>();
//            dic.Add("riddle", first);
//            dic.Add("ans", second);
//
//            allTextDic.Add(dic);
//        }
//
//        return allTextDic;
//
//    }
//
//    // Update is called once per frame
//    void Update () {
//		
//	}
//}
