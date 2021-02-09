using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Account
{
    public AccountInfo currentInfo;

    public Account(string email)
    {
        currentInfo.Email = email;
        currentInfo.Password = "12345";
        currentInfo.AccessLevel = 0;
    }

    public Account(string email, string password)
    {
        currentInfo.Email = email;
        currentInfo.Password = password;
        currentInfo.AccessLevel = 0;
    }

    public Account(string email, string password, int accessLevel)
    {
        currentInfo.Email = email;
        currentInfo.Password = password;
        currentInfo.AccessLevel = accessLevel;
    }

    public Account(AccountInfo info)
    {
        currentInfo = info;
    }
    public IEnumerator UpdateAI(AccountInfo info, string url)
    {
        currentInfo = info;

        WWW hs_get = new WWW(url + "email=" + currentInfo.Email + "&password=" + currentInfo.Password + "&acc_level=" + currentInfo.AccessLevel);

        yield return hs_get;

        Debug.Log(hs_get.text);
    }
}

public struct AccountInfo
{
    public string Email { get; set; }
    public string Password { get; set; }
    public int AccessLevel { get; set; }
}

