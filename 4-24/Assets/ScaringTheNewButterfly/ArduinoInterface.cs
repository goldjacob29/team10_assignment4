using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoInterface : MonoBehaviour {

    SerialPort interfaceStream;
    public string interfacePath = "COM3";
    public int baudRate = 9600;

    Animator butterflyAnimator;
    
	void Start () {
        butterflyAnimator = gameObject.GetComponent<Animator>();
        try
        {
            interfaceStream = new SerialPort(interfacePath, baudRate);
            interfaceStream.Open();
            interfaceStream.ReadTimeout = 1;
            Debug.Log("Opened.");
        } catch (System.IO.IOException e)
        {
            Debug.Log("Could not find the serial port named: " + interfacePath + " . Please check if you supplied the right one on the unity panel. Will shut down now.");
            Application.Quit();
        }
    }

    void Update()
    {
        try
        {
            if (String.Compare("K",interfaceStream.ReadLine()) <= 0)
            {
                butterflyAnimator.SetTrigger("Scared");
                //butterflyAnimator.ResetTrigger("Scared");

            }
        }
        catch (TimeoutException e) {
            Debug.Log(e);
        }
    }

    void OnDisable ()
    {
        interfaceStream.Close();
    }

    public void WriteToArduino (string m)
    {
        interfaceStream.WriteLine(m);
        interfaceStream.BaseStream.Flush();
    }

}
