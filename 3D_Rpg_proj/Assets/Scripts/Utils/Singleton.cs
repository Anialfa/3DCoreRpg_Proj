using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> where T:class,new() //意思是说，想继承他就必须是一个类，而且可以被实例化
{
    static T instance;
    public static T Instance
    {
        get {
            if (instance==null)
            {
                instance = new T(); 
            }
            return instance;
        }

    }

}
