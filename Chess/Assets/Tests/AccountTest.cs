using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

namespace Tests
{
    public class AccountTest
    {
        // A Test behaves as an ordinary method
        [Test]
        public void CurrentAccountTesting()
        {
            // Use the Assert class to test conditions
            Account testAccount = new Account(new AccountInfo { Email = "newuser@mail.ru", Password = "12345", AccessLevel = 0 });

            ApplicationManager.InitializeAccount(testAccount);

            Account getAccount = ApplicationManager.GetCurrentAccount();

            Assert.AreEqual(testAccount, getAccount);
        }

        [Test]
        public void CoursesManagerTest()
        {
            GameObject testGO = new GameObject();
            testGO.AddComponent<CoursesManager>();

            GameObject textGO1 = new GameObject();
            textGO1.AddComponent<TextMeshProUGUI>();

            GameObject textGO2 = new GameObject();
            textGO2.AddComponent<TextMeshProUGUI>();

            CoursesManager coursesManager = testGO.GetComponent<CoursesManager>();
            coursesManager.themeName = textGO1.GetComponent<TextMeshProUGUI>();
            coursesManager.description = textGO2.GetComponent<TextMeshProUGUI>();
            coursesManager.phpScriptUrl = "http://localhost/unity_test/select_page.php?";

            ApplicationManager.InitializeAccount(new Account("newuser@mail.ru", "12345", 0));

            coursesManager.Select("Связка_Что такое связка");

            Assert.IsNotNull(coursesManager.description.text);
        }

        
    }
}
