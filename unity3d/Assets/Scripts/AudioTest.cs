using UnityEngine;

using System.Collections;

using System.IO;

using System.Text;

public class AudioTest : MonoBehaviour
{
	

	void Start ()
	{
		KalimbaPd.Init();
		
		KalimbaPd.OpenFile("kalimbaTest.pd", "pd");
	}

	void OnGUI ()
	{
		if (GUI.Button (new Rect (10, 10, 100, 50), "acouphène")) 
		{
			KalimbaPd.SendBangToReceiver("acou");
		}
		
		if (GUI.Button (new Rect (10, 10+50+10, 100, 50), "presbyacousie")) 
		{
			KalimbaPd.SendBangToReceiver("presby");
		}

		if (GUI.Button (new Rect (10, 10+50+10+50+10, 100, 50), "transmission")) 
		{
			KalimbaPd.SendBangToReceiver("transm");
		}

        if (GUI.Button(new Rect(10, 10 + 50 + 10 + 50 + 10+50+10, 100, 50), "perception"))
        {
            KalimbaPd.SendBangToReceiver("percep");
        }


    }
}
