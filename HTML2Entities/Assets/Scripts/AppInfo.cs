using UnityEngine;
using UnityEngine.UI; 

public class AppInfo : MonoBehaviour {

	void Awake()
    {
        gameObject.GetComponent<Text>().text = "Written by Šimon Raichl, 2018 | MIT License | Version: " + Application.version;
	}
}
