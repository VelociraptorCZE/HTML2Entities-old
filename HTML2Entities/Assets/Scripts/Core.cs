using UnityEngine;
using UnityEngine.UI;

public class Core : MonoBehaviour {

    InputField input, output, downloadFromWeb;

    string[] entities = { "&lt;", "&gt;", "&amp;", "&quot;", "&apos;", "&copy;", "&reg;", "&euro;", "&cent;", "&pound;", "&yen;", "&sect;", "&verbar;", "&dollar;", "&num;", "&commat;" };
    string[] chars = { "<", ">", "&", ('"').ToString(), "'", "©", "®", "€", "¢", "£", "¥", "§", "|", "$", "#", "@" };

	void Awake () {
        var Init = gameObject.AddComponent<InitFields>() as InitFields;
        downloadFromWeb = Init.LoadInput("DownloadFromPageInputField");
        input = Init.LoadInput("HTMLInputField");
        output = Init.LoadInput("EntityOutputField");
    }

    void Convert()
    {
        output.text = "";
        foreach (char c in input.text)
        {
            string currentCharacter = c.ToString();
            for (int i = 0; i < chars.Length; i++)
            {
                if (currentCharacter == chars[i])
                {
                    currentCharacter = entities[i];
                }
            }
            output.text += currentCharacter;
        }
    }

    public void OnInputChange()
    {
        Convert();
    }

    public InputField GetInput()
    {
        return input;
    }

    public InputField GetOutput()
    {
        return output;
    }

    public InputField GetDownloadField()
    {
        return downloadFromWeb;
    }
}
