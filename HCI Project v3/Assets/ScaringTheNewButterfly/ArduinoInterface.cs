using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class ArduinoInterface : MonoBehaviour
{

    SerialPort interfaceStream;
    public string interfacePath = "COM3";
    public int baudRate = 9600;
    public Animator butterflyAnimator;
    public GameObject butterfly;

    public Transform target;
    Camera cam; 

    void Start()
    {
        butterfly = GameObject.FindGameObjectWithTag("Butterfly");
        butterflyAnimator = butterfly.GetComponent<Animator>();
        try
        {
            interfaceStream = new SerialPort(interfacePath, baudRate);
            interfaceStream.Open();
            interfaceStream.ReadTimeout = 1;
            Debug.Log("Opened.");
        }
        catch (System.IO.IOException e)
        {
            Debug.Log("Could not find the serial port named: " + interfacePath + " . Please check if you supplied the right one on the unity panel. Will shut down now.");
            Application.Quit();
        }

        cam = GetComponent<Camera>();

        //cam = GetComponent<m_MainCamera>();
    }

    void Update()
    {
        try
        {
            if (String.Compare("K", interfaceStream.ReadLine()) <= 0)
            {
                Debug.Log("Scared");
                butterflyAnimator.SetTrigger("Scared");
                //butterflyAnimator.ResetTrigger("Scared");

            }
        }
        catch (TimeoutException e)
        {
        }

        Vector3 ViewPos = cam.WorldToViewportPoint(target.position);
        if (ViewPos.x < 1 && ViewPos.x > 0
            && ViewPos.y < 1 && ViewPos.y > 0
            && ViewPos.z > 0)
        {
            Debug.Log("Visible");
            //WriteToArduino("b");
        } else
        {
            WriteToArduino(null);
        }
    }

    void OnDisable()
    {
        interfaceStream.Close();
    }

    public void WriteToArduino(string m)
    {
        interfaceStream.WriteLine(m);
        interfaceStream.BaseStream.Flush();
    }

}
