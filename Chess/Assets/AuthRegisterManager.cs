using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AuthRegisterManager : MonoBehaviour
{
    private string secretKey = "sssekret";
    public string addUserURL = "http://localhost/unity_test/insert_to_db.php?";
    public string selectUserURL = "http://localhost/unity_test/get_from_db.php?";

    public Text outputText;

    public TextMeshProUGUI emailRegText;
    public TextMeshProUGUI passRegText;
    public TextMeshProUGUI emailAuthText;
    public TextMeshProUGUI passAuthText;

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


        if (email != "" && email[0] != ((char)8203) && email != null && password[0] != ((char)8203) && password != null && password != "")
        {
            string post_url = addUserURL + "email=" + WWW.EscapeURL(email) + "&password=" + WWW.EscapeURL(password);

            WWW hs_post = new WWW(post_url);

            yield return hs_post;

            if (hs_post.error != null)
            {
                print("ERROR: " + hs_post.error);
            }
            else
            {
                outputText.text = "Успешно добавлен пользователь " + email;
                yield return new WaitForSeconds(2f);
                mainMenuPage.SetActive(true);
                authRegPage.SetActive(false);

            }
        }
        else
        {
            outputText.text = "Невозможно добавить пользователя. Проверьте вводимые данные";
        }
    }

    public IEnumerator SelectUser()
    {
        string login = emailAuthText.text;
        string password = passAuthText.text;

        WWW hs_get = new WWW(selectUserURL + "email=" + login + "&password=" + password);

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

                if (temp == "okey")
                {
                    outputText.text = "Пользователь " + login + " авторизирован";
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
