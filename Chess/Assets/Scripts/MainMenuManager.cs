using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public void OnExitButtonPressed()
    {
#if UNITY_STANDALONE

        Application.Quit();

#endif
    }
}
