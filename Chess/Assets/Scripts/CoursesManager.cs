using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoursesManager : MonoBehaviour
{
    public string phpScriptUrl;

    public TextMeshProUGUI themeName;
    public TextMeshProUGUI description;

    public void Start()
    {
        themeName.text = "";
        description.text = "";
    }

    public void Select(string parameters)
    {
        string[] parse = parameters.Split('_');
        StartCoroutine(SelectPage(parse[0], parse[1]));
    }

    public IEnumerator SelectPage(string theme, string pageName)
    {
        WWW getRequest = new WWW(phpScriptUrl + "themeName=" + WWW.EscapeURL(theme) +"&pageName=" + WWW.EscapeURL(pageName) + "&acc_level=" + ApplicationManager.GetCurrentAccount().currentInfo.AccessLevel);

        yield return getRequest;

        string text = getRequest.text;

        themeName.text = pageName;
        description.text = text;
    }

    public void OnEnable()
    {
        
    }
}
