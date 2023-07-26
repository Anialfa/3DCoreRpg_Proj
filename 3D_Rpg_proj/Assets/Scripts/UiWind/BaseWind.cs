using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWind 
{
    protected Transform SelfTransform { get; private set; }//Base的继承者可以获取值，但也只有直接继承者自己可以修改
    public abstract void Initial();

    public void CreateWind(string windName, Transform canvas)//利用反射获取预制体名称
    {
        GameObject originWnd = Resources.Load<GameObject>("Wnd/"+windName);//通过名称加载对应资源
        GameObject cloneWnd = GameObject.Instantiate(originWnd);
        SelfTransform = cloneWnd.transform;
        SelfTransform.SetParent(canvas, false);

    }

    public void OpenWind()
    {
        SelfTransform.gameObject.SetActive(true);
    }
    public void CloseWind()
    {
        SelfTransform.gameObject.SetActive(false);
    }

    protected virtual void OnOpenWnd()
    {
    
    }

    protected virtual void OnCloseWnd()
    {
    
    }
}
