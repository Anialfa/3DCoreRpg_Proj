using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;
public class DataManager : Singleton<DataManager>
{
    public void Initial()
    {
        string filePath = Application.streamingAssetsPath+"/item2.json";
        string jd = File.ReadAllText(filePath);
        Debug.Log($"{jd}");
        ItemInfo itemInfo = JsonConvert.DeserializeObject<ItemInfo>(jd);

        Debug.Log($"输出={itemInfo.i_name}+{itemInfo.i_id}");
    }


}

public class ItemInfo
{
    public string i_name;
    public int i_id;
}

