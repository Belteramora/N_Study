using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    public string addUserURL = "http://localhost/unity_test/insert_to_db.php?";
    public string selectUserURL = "http://localhost/unity_test/get_from_db.php?";
    public string updateAIURL = "http://localhost/unity_test/update_account_info.php?";

    public TMPro.TMP_InputField accLevel;

    private static Account currentAccount;
    
    public static void InitializeAccount(Account account)
    {
        currentAccount = account;
    }

    public static Account GetCurrentAccount()
    {
        return currentAccount;
    }

    public void UpdateAccountInfo()
    {
        StartCoroutine(currentAccount.UpdateAI(new AccountInfo { Email = currentAccount.currentInfo.Email, Password = currentAccount.currentInfo.Password, AccessLevel = Int32.Parse(accLevel.text) }, updateAIURL));
    }
}
