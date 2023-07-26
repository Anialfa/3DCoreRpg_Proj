using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour

{
    void Start()
    {
        Transform canvase = transform.Find("canvas");
        WinManager.Instance.Initial(canvase);
        WinManager.Instance.OpenWnd<StartWind>();

    }
   
}
