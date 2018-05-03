using System.Collections;
using System.Collections.Generic;
using System.IO;
using System;

using SharedLibrary;

public static class TestResults
{
    public static string _testName;

	private static int _TimeRan = 0;
	private static int _numOfPacketsMissed = 0;
	private static int _numOfPacketsLate = 0;
	private static List<PacketType> _latePacketTypes = new List<PacketType>();
	private static List<PacketType> _missedPacketTypes = new List<PacketType>();

	public static void IncrementPacketsMissed(PacketType type) //To show that the packet fimally arrived but just out of order.
	{
		_numOfPacketsMissed++;
		_missedPacketTypes.Add (type);
	}

	public static void IncrementPacketsLate(PacketType type) //To show that it has recognised that one has been missed.
	{
		_numOfPacketsLate++;
		_latePacketTypes.Add (type);
	}

	public static void WriteOutFile(int sendRate, int packetBackLog, string protocol, int numPacketsSent, int numPacketRecieved)
	{
        string path = "Data" + @"/";
		string date = DateTime.Now.ToLongDateString();
		string time = DateTime.Now.Hour.ToString() + "-" + DateTime.Now.Minute.ToString() + "-" + DateTime.Now.Second.ToString();
		string filenameEnding = "_" + date + "_" + time;
		using (StreamWriter outputfile = new StreamWriter (path + _testName + filenameEnding + ".txt"))
		{
			outputfile.WriteLine (_testName);
			outputfile.WriteLine ("Protocol Used: " + protocol);
			outputfile.WriteLine ("Packet Send: " + numPacketsSent.ToString());
			outputfile.WriteLine ("Packet Recieved: " + numPacketRecieved.ToString());
			outputfile.WriteLine ("Packet Back Log: " + packetBackLog.ToString());
			outputfile.WriteLine ("Packet Send Rate: " + sendRate.ToString());
			outputfile.WriteLine ("Number of Packets Missed: " + _numOfPacketsMissed.ToString());
			outputfile.WriteLine ("Number of Packets Late: " + _numOfPacketsLate.ToString());
		}
	}
}
