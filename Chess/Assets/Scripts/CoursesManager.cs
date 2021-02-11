using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoursesManager : MonoBehaviour
{
    public string phpScriptUrl;

    public TextMeshProUGUI themeTextMesh;
    public TextMeshProUGUI descriptionTextMesh;

    public void Start()
    {
        themeTextMesh.text = "";
        descriptionTextMesh.text = "";
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

        themeTextMesh.text = pageName;
        descriptionTextMesh.text = text;
    }

    public void OnEnable()
    {
        
    }
}
