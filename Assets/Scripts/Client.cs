using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using System.IO;
using System.Net.WebSockets;
using UnityEngine;

public class Client : MonoBehaviour
{
    private TcpClient client;
    private NetworkStream stream;
    private StreamWriter writer;
    private StreamReader reader;

    public void Connect(string host, int port)
    {
        if (null != client) return; 
        client = new TcpClient();
        client.BeginConnect(host, port, new AsyncCallback(ConnectCallback), client);
    }

    public void Send(string data)
    {
        if (!IsConnected()) return;
        writer.WriteLine(data);
        writer.Flush();
    }

    private void OnReceiveMessage(string data)
    {

    }

    private void Update()
    {
        if (IsConnected() && stream.DataAvailable)
        {
            string data = reader.ReadLine();
            if (null != data) OnReceiveMessage(data);
        }
    }

    private void ConnectCallback(IAsyncResult asyncResult)
    {
        TcpClient t = (TcpClient)asyncResult.AsyncState;
        try
        {
            if (t.Connected)
            {
                t.EndConnect(asyncResult);
                stream = client.GetStream();
                writer = new StreamWriter(stream);
                reader = new StreamReader(stream);
                Debug.Log("客户端连接成功");
            }
            else
            {
                Close();
                Debug.Log("客户端连接失败");
            }
        } catch (Exception e)
        {
            Debug.Log(e.Message);
        }
    }

    void Close()
    {
        if (null != writer)
        {
            writer.Close();
            writer = null;
        }
        if (null != reader) {
            reader.Close();
            reader = null;
        }
        if (null != client)
        {
            client.Close();
            client = null;
        }
    }

    private void OnApplicationQuit()
    {
        Close();
    }

    public bool IsConnected()
    {
        return null != client && client.Connected;
    }
}
