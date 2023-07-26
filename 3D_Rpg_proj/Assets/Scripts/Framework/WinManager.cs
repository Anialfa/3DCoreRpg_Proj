using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinManager : Singleton<WinManager> //winManager继承单例泛型类后，windmanager也变单例了
{
    Dictionary<string, BaseWind> _allWnds;

    Transform _canvase;

    public void Initial(Transform canvas)
    {
        _canvase = canvas;
        _allWnds = new Dictionary<string, BaseWind>();
    }

    /// <summary>
    /// 泛型方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public void OpenWnd<T>() where T : BaseWind, new()
    {
        string wndName = typeof(T).Name;//通过反射获取窗口的名字
        if (_allWnds.ContainsKey(wndName))
        {
            _allWnds[wndName].OpenWind();
        }
        else
        {
            T wnd = new T();
           
            wnd.CreateWind(wndName, _canvase);
            wnd.Initial();
            _allWnds.Add(wndName, wnd);
        }

    }

    public void CloseWnd<T>()where T : BaseWind,new()
    {
        string wndName = typeof(T).Name;
        _allWnds[wndName].CloseWind();

    }

    public T GetWnd<T>() where T : BaseWind, new()
    {
        string wndName = typeof(T).Name;
        if (_allWnds.ContainsKey(wndName))
        {
            return _allWnds[wndName] as T;
        }
        else
        {
            return null;
        }

    }

}
