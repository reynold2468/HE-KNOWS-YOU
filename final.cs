using UnityEngine; 
using System.Collections; 
using System.Xml; 
using System.Xml.Serialization; 
using System.IO; 
using System.Text; 
using System;

public class final : MonoBehaviour {
	trackmove tm;
	string FileLocation,FileName; 
	string data;
	//public GameObject Player;



	// Use this for initialization
	void Start () {
		FileLocation=Application.dataPath; 
		FileName="madachod.xml"; 
		tm=new trackmove();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnGUI()
	{
		if (GUI.Button(new Rect(10,80,100,20), "Save")) 
		{
			tm.iUser.x = 5;
			tm.iUser.y = 25;
			tm.iUser.z =30;
			data = SerializeObject (tm);
			CreateXML ();
		}
	}
	void Save(){
		
	}
	string UTF8ByteArrayToString(byte[] characters) 
	{      
		UTF8Encoding encoding = new UTF8Encoding(); 
		string constructedString = encoding.GetString(characters); 
		return (constructedString); 
	} 

	string SerializeObject(object pObject) 
	{ 
		string XmlizedString=null; 
		MemoryStream memoryStream = new MemoryStream(); 
		XmlSerializer xs = new XmlSerializer(typeof(trackmove)); 
		XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, Encoding.UTF8); 
		xs.Serialize(xmlTextWriter, pObject); 
		memoryStream = (MemoryStream)xmlTextWriter.BaseStream; 
		XmlizedString = UTF8ByteArrayToString(memoryStream.ToArray()); 
		return XmlizedString; 
	}

	void CreateXML() 
	{ 
		StreamWriter writer; 
		FileInfo t = new FileInfo(FileLocation+"\\"+ FileName); 
		if(!t.Exists) 
		{ 
			writer = t.CreateText(); 
		} 
		else 
		{ 
			t.Delete(); 
			writer = t.CreateText(); 
		} 
		writer.Write(data); 
		writer.Close(); 
		Debug.Log("File written."); 
		print("aaaaaaa");
	} 


}

public class trackmove
{
	public DemoData iUser; 
	// Default constructor doesn't really do anything at the moment 
	public trackmove() { }
	public struct DemoData{
	public float x;
	public float y;
	public float z;
	}
}