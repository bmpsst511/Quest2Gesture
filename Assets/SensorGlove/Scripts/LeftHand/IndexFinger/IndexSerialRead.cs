using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.IO.Ports;

public class IndexSerialRead : MonoBehaviour
{
SerialPort sp=new SerialPort("/dev/cu.usbserial-14410",115200);
//float num=0;
// Use this for initialization
void Start () {
	sp.Open ();
	sp.ReadTimeout = 1;
}
// Update is called once per frame
void Update () {
	if (sp.IsOpen) {
		try{
			float data= float.Parse(sp.ReadLine());
			print(data);
			//this.gameObject.transorm.Rotate(new Vector3(0f,0f,data));
		}
		catch(System.Exception){
		}
	}
}
}	
