using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Xml;
using System.Net;

public class Savefinal : MonoBehaviour
{
	public GameObject trackedPlayer;
	public GameObject calibration;
	public bool bLog = true;
	private static XmlWriterSettings fragmentSettings;
	private string logFilePath, logFileDir,wrappername;
	static FileStream logfile;
	static string trackerDir = "Assets";
	private static XmlWriterSettings wrapperSettings ;


	void Start()
	{

		if (bLog) {
			PrepareLog ();
		}



	}

	// Use this for initialization
	void PrepareLog ()
	{
		print("******************* LOGFILE STARTING *****************");

		//        print("TODO AUTO CREATE DIRECTORY at Savestatistics.cs...");

		string basename = DateTime.Now.ToOADate ().ToString ();
		//string basename = .ToString();
		logFileDir = Path.GetDirectoryName(Application.dataPath)+"/"+trackerDir+"/";

		if (!Directory.Exists(logFileDir))
			Directory.CreateDirectory(logFileDir);


		string wrappername = logFileDir + "wrapper"+ ".xml";
		//logFilePath = logFileDir + "log" + ".xml";

	
	
		// Write the wrapper file

		string doctype = "<!DOCTYPE trackerdata \n [ \n <!ENTITY locations SYSTEM \"log-" + basename + ".xml\">\n ]>";
		wrapperSettings.Indent = true;
		using (XmlWriter writer = XmlWriter.Create (wrappername, wrapperSettings)) {
			writer.WriteStartDocument();
			writer.WriteRaw (doctype); 
			writer.WriteStartElement ("trackerdata");
			InvokeRepeating("Initialdoc", 0, 3); //collect data every 3 seconds

		}

		// Prepare the log XML fragment
//		logfile = new FileStream (logFilePath,FileMode.Append, FileAccess.Write, FileShare.Read);
//		//logfile = new FileStream (logFilePath,FileMode.Append, FileAccess.Write);
//		fragmentSettings = new XmlWriterSettings ();
//		fragmentSettings.ConformanceLevel = ConformanceLevel.Fragment;
//		fragmentSettings.Indent = true;
//		fragmentSettings.OmitXmlDeclaration = false;




		//writer.WriteEndElement();




	}


	void Initialdoc()
	{
		wrapperSettings.Indent = true;
		using (XmlWriter writer = XmlWriter.Create (wrappername, wrapperSettings)) {
			writer.WriteStartElement ("location");

			writer.WriteStartElement ("x");
			writer.WriteValue (trackedPlayer.transform.position.x);
			writer.WriteEndElement ();

			writer.WriteStartElement ("y");
			writer.WriteValue (trackedPlayer.transform.position.y);
			writer.WriteEndElement ();

			writer.WriteStartElement ("z");
			writer.WriteValue (trackedPlayer.transform.position.z);
			writer.WriteEndElement ();

			writer.WriteEndElement ();
			// /meta

			writer.WriteStartElement ("tracking");
			writer.WriteEntityRef ("locations");      
			writer.Close ();
		}
		if (bLog == false) {
		
		}
	}

}

