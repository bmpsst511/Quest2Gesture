using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//引入庫  
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System;

public class IndexEndFingerCurve : MonoBehaviour
{
     //以下默認都是私有的成員  
    Socket socket; //目標socket  
    EndPoint clientEnd; //客户端  
    IPEndPoint ipEnd; //偵聽端口  
    public static int Index, Middle, Ring, Pinky, Thumb, cal_index; 
    public int port; //宣告端口
    string recvStr; //接收的字符串 
    string sendStr; //發送的字符串
    byte[] recvData = new byte[1024]; //接收的數據，必須為字節  
    byte[] sendData = new byte[1024]; //發送的數據，必須為字節
    int recvLen; //接收的數據長度
    Thread connectThread; //連接線程  
    public float level = 9;
    public static float multi_val; //放大器
    [SerializeField]
    float eulerAngX;
    [SerializeField]
    float eulerAngY;
    [SerializeField]
    float eulerAngZ;


    void InitSocket()
    {
        //定義偵聽端口,偵聽任何IP  
        //ipEnd = new IPEndPoint(IPAddress.Parse("172.20.10.2"), port);
        ipEnd = new IPEndPoint(IPAddress.Any, port);
        //定義套接字類型,在主線程中定義 
        socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        //服務端需要綁定ip  
        socket.Bind(ipEnd);
        //定義客戶端
        IPEndPoint sender = new IPEndPoint(IPAddress.Any, port);
        clientEnd = (EndPoint)sender;
        print("waiting for UDP dgram");

        //開啟一個線程連接，必須的，否則主線程卡死 
        connectThread = new Thread(new ThreadStart(SocketReceive));
        connectThread.Start();
    }

    void SocketReceive()
    {
        //進入接收循環
        while (true)
        {
            //對data清零  
            recvData = new byte[1024];
            //獲取客戶端，獲取客戶端數據，用引用給客戶端賦值
            recvLen = socket.ReceiveFrom(recvData, ref clientEnd);
            //print("message from: " + clientEnd.ToString()); //列印客户端信息  
            //輸出接收到的數據 
            recvStr = Encoding.ASCII.GetString(recvData, 0, recvLen);
            //print(recvStr);
            char[] splitChar = { ' ', ',', ':', '\t', ';' };
            string[] dataRaw = recvStr.Split(splitChar);
            Index = int.Parse(dataRaw[0]);
            Middle = int.Parse(dataRaw[1]);
            Ring = int.Parse(dataRaw[2]);
            Pinky = int.Parse(dataRaw[3]);
            Thumb = int.Parse(dataRaw[4]);
        }
    }

        //連接關閉
    void SocketQuit()
    {
        //關閉線程 
        if (connectThread != null)
        {
            connectThread.Interrupt();
            connectThread.Abort();
        }
        //最後關閉socket
        if (socket != null)
            socket.Close();
        print("disconnect");
    }


    // Start is called before the first frame update
    void Start()
    {
        InitSocket();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        multi_val = level;
        /*************讓收到的感測器值轉成int******************/
        cal_index = Index - FingerCalibration.Ini_index; //從校正腳本得到的數值與目前數值相減讓起始值等於0
        eulerAngX = transform.localEulerAngles.x;
        eulerAngY = transform.localEulerAngles.y;
        eulerAngZ = transform.localEulerAngles.z;
        
        this.transform.localRotation = Quaternion.Euler(eulerAngX, eulerAngY, -1*cal_index*multi_val);
    }

    void onApplicationQuit()
    {
        SocketQuit();
    }
}
