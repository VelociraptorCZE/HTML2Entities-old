using System.Net;
using UnityEngine;
using UnityEngine.UI;

public class Features : MonoBehaviour{

    Core Core;
    GameObject[] windows = new GameObject[2];
    Text ErrorMessage;

    void Awake()
    {
        Core = GameObject.Find("CoreController").GetComponent<Core>();
        AddWindow(0, "DownloadWebPageWindow");
        AddWindow(1, "ErrorWindow");
        ErrorMessage = GameObject.Find("ErrorMessage").GetComponent<Text>();
    }

    void AddWindow(int id, string name)
    {
        windows[id] = GameObject.Find(name);
    }

	public void DownloadPage()
    {
        using (WebClient req = new WebClient())
        {
            try
            {
                string web = Core.GetDownloadField().text;
                if (!web.Contains("http://") && !web.Contains("https://"))
                {
                    web = "http://" + web;
                }
                if (web.Contains("https://"))
                {
                    throw new ProtocolViolationException();
                }
                Core.GetInput().text = req.DownloadString(web);
            }
            catch(System.Exception e)
            {
                ErrorMessage.text = "Something went wrong, error dump: " + e;
                ToggleWindow(1);
            }
        }
	}
	
    public void CopyToClipboard()
    {
        TextEditor txt = new TextEditor();
        txt.text = Core.GetOutput().text;
        txt.SelectAll();
        txt.Copy();
    }

    public void ToggleWindow(int id)
    {  
        if (windows[id].transform.localScale == new Vector3(0, 1, 1))
        {
            windows[id].transform.localScale = new Vector3(1, 1, 1);
        }
        else
        {
            windows[id].transform.localScale = new Vector3(0, 1, 1);
        }
    }
}
