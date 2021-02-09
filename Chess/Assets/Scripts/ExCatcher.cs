using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ExCatcher : MonoBehaviour
{
    public void Catcher()
    {
        try
        {
            Debug.Log("Ошибок не обнаружено");
            throw new ApplicationException("Ошибка - ApplicationException");
        }
        catch(ApplicationException e)
        {
            Debug.Log(e.Message);
        }
        catch
        {
            Debug.Log("Обнаружена ошибка");
        }
    }
}
