using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AuthRegisterManager : MonoBehaviour
{
    [Header("Application Manager")]
    public ApplicationManager manager;

    [Header("Output")]
    [Space(10)]
    public Text outputText;

    [Header("Input")]
    [Space(10)]
    public TextMeshProUGUI emailRegText;
    public TMP_InputField passRegText;
    public TextMeshProUGUI emailAuthText;
    public TMP_InputField passAuthText;

    [Header("Pages")]
    [Space(10)]
    public GameObject authRegPage;
    public GameObject mainMenuPage;

    public void InsertToDB()
    {
        StartCoroutine(InsertUser());
    }

    public void Authorize()
    {
        StartCoroutine(SelectUser());
    }


    public IEnumerator InsertUser()
    {
        string email = emailRegText.text;
        string password = passRegText.text;

        Debug.Log("Email: " + email + " || Password: " + password);

        if (email != "" && email[0] != ((char)8203) && email != null)
        {
            if (IsValidEmail(email))
            {
                if (password[0] != ((char)8203) && password != null && password != "")
                {
                    string post_url = manager.addUserURL + "email=" + email + "&password=" + password;

                    WWW hs_post = new WWW(post_url);

                    yield return hs_post;

                    if (hs_post.error != null)
                    {
                        print("ERROR: " + hs_post.error);
                    }
                    else
                    {
                        outputText.text = "Успешно добавлен пользователь " + email;
                        
                        ApplicationManager.InitializeAccount(new Account(new AccountInfo { Email = email, Password = password, AccessLevel = 0 }));
                        yield return new WaitForSeconds(2f);
                        mainMenuPage.SetActive(true);
                        authRegPage.SetActive(false);

                    }
                }
                else
                {
                    outputText.text = "В поле пароля пусто, пожалуйста, введите данные";
                }
            }
            else
            {
                outputText.text = "Некорректный e-mail. Проверьте введенные данные и повторите попытку";
            }
        }
        else
        {
            outputText.text = "В поле e-mail пусто, пожалуйста, введите данные";
        }
    }

    public bool IsValidEmail(string email)
    {
        string pattern = "[.\\-_a-z0-9]+@([a-z0-9][\\-a-z0-9]+\\.)+[a-z]{2,6}";
        Match isMatch = Regex.Match(email, pattern, RegexOptions.IgnoreCase);
        return isMatch.Success;
    }

    public IEnumerator SelectUser()
    {
        string login = emailAuthText.text;
        string password = passAuthText.text;

        Debug.Log("Login: " + login + " || Password: " + password);

        WWW hs_get = new WWW(manager.selectUserURL + "email=" + login + "&password=" + password);

        yield return hs_get;

        string temp;

        if (hs_get.error != null)
        {
            print("ERROR: " + hs_get.error);
        }
        else
        {
            Debug.Log(login + " " + password);

            if (login != null && login != "" && login[0] != ((char)8203) && password != null && password != "" && password[0] != ((char)8203))
            {
                temp = hs_get.text;

                Debug.Log(temp);

                string[] arr = temp.Split('-');

                if (arr[0] == "okey")
                {
                    outputText.text = "Пользователь " + login + " авторизирован";
                    ApplicationManager.InitializeAccount(new Account(login, password, Int32.Parse(arr[1])));
                    yield return new WaitForSeconds(2f);
                    mainMenuPage.SetActive(true);
                    authRegPage.SetActive(false);
                }
                else
                {
                    outputText.text = "Неверный логин или пароль";
                }
            }
            else
            {
                outputText.text = "Невозможно авторизоваться. Проверьте данные";
            }
        }
    }
}
