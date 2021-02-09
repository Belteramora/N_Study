using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoManager : MonoBehaviour
{
    [SerializeField]
    private string phpScriptUrl;

    public TextMeshProUGUI themeName;
    public TextMeshProUGUI description;

    private void Start()
    {
        Select("Общие сведеия");
    }

    public void Select(string infoName)
    {
        StartCoroutine(SelectInfo(infoName));
    }

    private IEnumerator SelectInfo(string infoName)
    {
        WWW getRequest = new WWW(phpScriptUrl + "infoName=" + WWW.EscapeURL(infoName));

        Debug.Log(phpScriptUrl);
        Debug.Log(infoName);

        yield return getRequest;

        string text = getRequest.text;

        themeName.text = infoName;
        description.text = text;
    }
}
