using UnityEngine;
using UnityEngine.UI;

public class InitFields : MonoBehaviour {

	public InputField LoadInput(string param)
    {
        try
        {
            return GameObject.Find(param).GetComponent<InputField>();
        }
        catch
        {
            return null;
        }
	}
}
