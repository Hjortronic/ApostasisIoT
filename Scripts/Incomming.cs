using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using SimpleJSON;

public abstract class Incomming : Part {

    private static string URL = "apostasis.eu/DesktopModules/InterconnectionFrameworkModule/API/restv1/D1654A27-5fb6-4f6A-986B-979170BD05C8/read/f?key=";

    public Reaction reaction;
    string key;

    void _GetValue()
    {
        StartCoroutine(GetValue());
    }

    IEnumerator GetValue()
    {

        if (!string.IsNullOrEmpty(key)) {

        using (UnityWebRequest www = UnityWebRequest.Get(URL + key))
        {
            yield return www.Send();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                var res = JSON.Parse(www.downloadHandler.text);
                float value = res["value"].AsFloat;

                if (reaction) reaction.Handle(value);
            }
        }
        }
    }
	void Start () {
        key = gameObject.transform.parent.name + "_" + gameObject.name;
        InvokeRepeating("_GetValue", 0.0f, 2.0f);
	}
}