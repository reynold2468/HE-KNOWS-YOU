using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Xml;
using System.Net;

public class SaveStatistics : MonoBehaviour
{
	public GameObject trackedPlayer;
	public GameObject calibration;
	public string version = "Prototype_0.1";
	public bool bLog = true;
	private static XmlWriterSettings fragmentSettings;
	private string logFilePath, logFileDir;
	public Transform enemy;
	public Transform spawnpoint; 
	//public int sync;
	static FileStream logfile;
	public bool randombool = true;
	static string trackerDir = "Assets";
	public int sync=0;
	void Start()
	{
		
		if (bLog) {
			
			PrepareLog ();
		}	

//		if(spawnpoint.position == this.transform.position) {
//			bLog = true;
//
//		}

//		if (Vector3.Distance (enemy.position, this.transform.position) < 5) {
//			bLog = false;
//		}

	}
	void Update(){
		if(spawnpoint.position == this.transform.position) {
			bLog = true;

			if (randombool) {												//not working
				PrepareLog ();
				randombool = false;
			}
		}
//		Vector3 direction = enemy.position - this.transform.position;
		Vector3 direction = enemy.position - this.transform.position;
		if (Vector3.Distance (enemy.position, this.transform.position) < 5) {
			bLog = false;
		}

	}

	// Use this for initialization
	void PrepareLog ()
	{
		
		sync++;
		print("******************* LOGFILE STARTING *****************");
		XmlWriterSettings wrapperSettings = new XmlWriterSettings ();
		wrapperSettings.Indent = true;

		//        print("TODO AUTO CREATE DIRECTORY at Savestatistics.cs...");

		string basename = DateTime.Now.ToOADate ().ToString ();
		//string basename = .ToString();
		logFileDir = Path.GetDirectoryName(Application.dataPath)+"/"+trackerDir+"/";

		if (!Directory.Exists(logFileDir))
			Directory.CreateDirectory(logFileDir);


		string wrappername = logFileDir + "wrapper"+ ".xml";
		logFilePath = logFileDir + "log" + sync+".xml";
//		if (File.Exists (logFilePath)) {
//			sync = sync+ 1;
//			logFilePath = logFileDir + "log" + sync + ".xml";
//		}
		//trackedPlayer = GameObject.FindGameObjectWithTag ("Player");
		if(trackedPlayer != null)
		{
			//hb = trackedPlayer.GetComponent<Healthbar>();

		}

		// Write the wrapper file

		string doctype = "<!DOCTYPE trackerdata \n [ \n <!ENTITY locations SYSTEM \"log-" + basename + ".xml\">\n ]>";

		using (XmlWriter writer = XmlWriter.Create (wrappername, wrapperSettings)) {
			writer.WriteStartDocument();
			writer.WriteRaw (doctype); 
			writer.WriteStartElement ("trackerdata");

			// meta
			writer.WriteStartElement ("meta");


			writer.WriteStartElement ("starttime");
			writer.WriteValue (DateTime.Now);
			writer.WriteEndElement ();

//			writer.WriteStartElement("hostname");
//			writer.WriteValue(Dns.GetHostName());
//			writer.WriteEndElement();
//
//			writer.WriteStartElement("playername");
//			writer.WriteValue(PlayerPrefs.GetString("Name"));
//			writer.WriteEndElement();
//
//			writer.WriteStartElement("playerscore");
//			writer.WriteValue(PlayerPrefs.GetInt("PlayerScore"));
//			writer.WriteEndElement();
//
//			writer.WriteElementString ("levelversion", version);

			writer.WriteEndElement ();
			// /meta

			writer.WriteStartElement ("tracking");
			writer.WriteEntityRef ("locations");            
			writer.Close ();
		}

		// Prepare the log XML fragment
		logfile = new FileStream (logFilePath,FileMode.Append, FileAccess.Write, FileShare.Read);
		//logfile = new FileStream (logFilePath,FileMode.Append, FileAccess.Write);
		fragmentSettings = new XmlWriterSettings ();
		fragmentSettings.ConformanceLevel = ConformanceLevel.Fragment;
		fragmentSettings.Indent = true;
		fragmentSettings.OmitXmlDeclaration = false;

		Initialdoc ();
		InvokeRepeating("CollectData", 0, 1); //collect data every 3 seconds

			//writer.WriteEndElement();

			

	}

	void CollectData ()
	{
		
		int my_x = Mathf.RoundToInt(trackedPlayer.transform.position.x);
		int my_y = Mathf.RoundToInt (trackedPlayer.transform.position.y);
		int my_z=  Mathf.RoundToInt (trackedPlayer.transform.position.z);
		using (XmlWriter writer = XmlWriter.Create (logfile, fragmentSettings)) {

			//writer.WriteStartDocument();
			//writer.WriteStartElement ("PlayerData");
			writer.WriteStartElement ("tracked");
			writer.WriteStartAttribute ("runningTime");
			writer.WriteValue (Time.timeSinceLevelLoad);
			writer.WriteEndAttribute ();
//			writer.WriteStartElement ("\n");


			writer.WriteStartElement ("x");
			writer.WriteValue (my_x);
			writer.WriteEndElement ();

			writer.WriteStartElement ("y");
			writer.WriteValue (my_y);
			writer.WriteEndElement ();

			writer.WriteStartElement ("z");
			writer.WriteValue (my_z);
			writer.WriteEndElement ();

			writer.WriteEndElement ();
			writer.Flush ();

		}
		logfile.Flush ();

		if (bLog == false) {
			string CLOSE=("</PlayerData>");
			string CLOSEsubclass=("</location>");
			using (XmlWriter writer = XmlWriter.Create (logfile, fragmentSettings)) {
				writer.WriteRaw (CLOSEsubclass);
				writer.WriteRaw(CLOSE);

				writer.Close();
			}
			logfile.Close ();
			randombool = true;
		}


	}

	void Initialdoc()
	{
		string INIT=("<PlayerData>");
		string subclass=("<location>");
		using (XmlWriter writer = XmlWriter.Create (logfile, fragmentSettings)) {
			//writer.WriteStartDocument();

			//writer.WriteStartElement ("PlayerData123");
			writer.WriteRaw (INIT);
			writer.WriteRaw (subclass);
		}
	}





	public static void AddEventInfo(string nodename, string value)
	{
		using (XmlWriter writer = XmlWriter.Create (logfile, fragmentSettings)) {
			writer.WriteStartElement ("event");

			writer.WriteStartAttribute ("runningTime");
			writer.WriteValue (Time.timeSinceLevelLoad);
			writer.WriteEndAttribute ();

			writer.WriteStartElement (nodename);
			writer.WriteValue (value);
			writer.WriteEndElement ();

			writer.WriteEndElement ();
			writer.Flush ();

		}

		logfile.Flush ();   

	}

	public static void AddPlayerStats(string nodename, string value)
	{
		using (XmlWriter writer = XmlWriter.Create (logfile, fragmentSettings)) {
			writer.WriteStartElement ("playerstats");

			writer.WriteStartAttribute ("runningTime");
			writer.WriteValue (Time.timeSinceLevelLoad);
			writer.WriteEndAttribute ();

			writer.WriteStartElement (nodename);
			writer.WriteValue (value);
			writer.WriteEndElement ();

			writer.WriteEndElement ();
			writer.Flush ();

		}

		logfile.Flush ();    
	}

	public static void AddHitEventInfo(string nodename, string value)
	{
		using (XmlWriter writer = XmlWriter.Create (logfile, fragmentSettings)) {
			writer.WriteStartElement ("hitevent");

			writer.WriteStartAttribute ("runningTime");
			writer.WriteValue (Time.timeSinceLevelLoad);
			writer.WriteEndAttribute ();

			writer.WriteStartElement (nodename);
			writer.WriteValue (value);
			writer.WriteEndElement ();

			writer.WriteEndElement ();
			writer.Flush ();

		}

		logfile.Flush ();    
	}
}
