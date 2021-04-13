using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickHost()
    {
        Server server = GetComponent<Server>();
        server.Init();
    }

    public void OnClickClient()
    {
        Client client = GetComponent<Client>();
        client.Connect("127.0.0.1", GetComponent<Server>().port);
    }
}
