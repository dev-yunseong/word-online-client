using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

namespace Script.Data
{
    public class Server
    {
        public Server(string name, string host, int port, bool isSecure = false)
        {
            this.name = name;
            this.host = host;
            this.port = port;
            this.isSecure = isSecure;
        }

        public string name;
        public string host;
        public int port;
        public bool isSecure;
        public string url => $"{(isSecure ? "https" : "http")}://{host}:{port}";
        public string webSocketUrl => $"{(isSecure ? "wss" : "ws")}://{host}:{port}/ws?token=";
        
        public IEnumerator GetPing(Action<int> callback)
        {
            DateTime startTime = DateTime.Now;
            using var www = new UnityWebRequest($"{url}/healthcheck", "GET");
            
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                DateTime endTime = DateTime.Now;
                int ping = (int)(endTime - startTime).TotalMilliseconds;
                callback?.Invoke(ping);
            }
            else
            {
                callback?.Invoke(-1);
            }
        }
    }
    
    public static class ServerList
    {
        public static List<Server> servers = new()
        {
            new Server("시드니", "www.monolong.shop", 7777, true),
            new Server("로컬", "localhost", 7777)
        };
    }
}