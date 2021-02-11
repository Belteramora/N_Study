using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;

namespace Tests
{
    public class ChessTest
    {
        
        [Test] // Атрибут для определения метода-тестировщика
        public void CurrentAccountTesting() // Начало метода-тестировщика
        {
            // Объявление и инициализация переменной Account посредством передачи в конструктор новой структуры AccountInfo с полями Email, Password и AccessLevel
            Account testAccount = new Account(new AccountInfo { Email = "newuser@mail.ru", Password = "12345", AccessLevel = 0 });

            // Инициализация нового аккаунта у класса ApplicationManager
            ApplicationManager.InitializeAccount(testAccount);

            // Объявление и инициализация переменной getAccount возвращаемым значением метода GetCurrentAccount класса ApplicationManagers
            Account getAccount = ApplicationManager.GetCurrentAccount();

            // Проверка на равенство переменных testAccount и getAccount
            Assert.AreEqual(testAccount, getAccount);
        }

        [UnityTest] // Специальный атрибут Unity для возможности создания задержек исполнения теста
        public IEnumerator CoursesManagerTest() // начало метода-тестировщика
        {
            // Создание игрового объекта testGO и добавление к нему компонента CoursesManager
            GameObject testGO = new GameObject();
            testGO.AddComponent<CoursesManager>();

            // Создание игрового объекта textGO1 и добавление к нему компонента TextMeshProUGUI
            GameObject textGO1 = new GameObject();
            textGO1.AddComponent<TextMeshProUGUI>();

            // Создание игрового объекта textGO2 и добавление к нему компонента TextMeshProUGUI
            GameObject textGO2 = new GameObject();
            textGO2.AddComponent<TextMeshProUGUI>();

            // Объявление переменной coursesManager и ее инициализация компонентом объекта testGO
            CoursesManager coursesManager = testGO.GetComponent<CoursesManager>();
            // Инициализация переменной themeTextMesh компонентом TextMeshProUGUI объекта textGO1
            coursesManager.themeTextMesh = textGO1.GetComponent<TextMeshProUGUI>();
            // Инициализация переменной descriptionTextMesh компонентом TextMeshProUGUI объекта textGO2
            coursesManager.descriptionTextMesh = textGO2.GetComponent<TextMeshProUGUI>();
            // Инициализация строковой переменной phpScriptUrl строкой 
            coursesManager.phpScriptUrl = "http://localhost/unity_test/select_pages.php?";

            // Инициализация нового аккаунта
            ApplicationManager.InitializeAccount(new Account("newuser@mail.ru", "12345", 0));

            // Вызов функции Select объекта coursesManager с передачей строкового параметра
            coursesManager.Select("Связка_Что такое связка");

            // Задержка выполнения на 0.2 секунды
            yield return new WaitForSeconds(0.2f);

            // Проверка на пустое значение переменной descriptionTextMesh объекта coursesManager
            Assert.IsEmpty(coursesManager.descriptionTextMesh.text);
        }

        
    }
}
