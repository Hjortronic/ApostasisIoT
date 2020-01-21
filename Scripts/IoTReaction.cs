using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class IoTReaction: Reaction {

public string password;
public string key;

private string URL = "apostasis.eu:80/DesktopModules/InterconnectionFrameworkModule/API/restv1/D1654A27-5fb6-4f6A-986B-979170BD05C8/cwrite/f";

    void Handle(float value) {
        StartCoroutine(Post(value));
    }

    IEnumerator Post(float value) {
        List<IMultipartFormSection> formData = new List<IMultipartFormSection>();
        
        formData.Add(new MultipartFormDataSection( "password="+password+"&key="+key+"&value="+string.Format("{0:N2}", value)));

        UnityWebRequest www = UnityWebRequest.Post(URL, formData);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Form upload complete!");
        }   
    }
}