using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class StartWind : BaseWind
{
    public override void Initial()
    {
        Button startbtn = SelfTransform.Find("StartBtn").GetComponent<Button>();
        Button exittbtn = SelfTransform.Find("QuitBtn").GetComponent<Button>();

        startbtn.onClick.AddListener(OnStartClick);
        exittbtn.onClick.AddListener(OnExittClick);
    }

    //点击退出游戏
    private void OnExittClick()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
        Application.Quit();
#endif
    }

    private void OnStartClick()
    {
        CloseWind();
    }
}
