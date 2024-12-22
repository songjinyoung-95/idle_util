using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GMTManager : MonoBehaviour
{
    private const string URL = "www.google.com";
    
    private void Start()
    {
        StartCoroutine(WebCheck());
    }
    
    private IEnumerator WebCheck()
    {
        UnityWebRequest request = new UnityWebRequest();

        using(request = UnityWebRequest.Get(URL))
        {
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.Success)
            {
                string date = request.GetResponseHeader("date");

                DateTime gmtTime    = DateTime.Parse(date).ToUniversalTime();
                DateTime localTime  = TimeZoneInfo.ConvertTimeFromUtc(gmtTime, TimeZoneInfo.Local);

                Debug.Log($"GMT : {date}");
                Debug.Log($"Local : {localTime}");
            }
        }
    }
}
