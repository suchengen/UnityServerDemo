using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using UnityEngine;

public class Server : MonoBehaviour
{
    public int port = 6321;

    public bool initOnStart = false;

    private TcpListener server;

    private bool isRunning;

    List<Client> clientList;
    List<Client> disconnectList;

    private void Awake()
    {
        clientList = new List<Client>();
        disconnectList = new List<Client>();
    }

    void Start()
    {
        if (this.initOnStart) this.Init();
    }

    public void Init()
    {   
        try
        {
            server = new TcpListener(IPAddress.Any, port);
            server.Start();
            server.BeginAcceptTcpClient(OnAcceptTcpClient, server);
            Debug.Log("server start success");
            
        }
         catch (Exception e)
        {
            Debug.Log(e.Message);
        }
        
        
    }

    //监听是否有客户端加入
    private void OnAcceptTcpClient(IAsyncResult ar)
    {
        Debug.Log("new player join");
    }

    private void Update()
    {
        
    }


}
