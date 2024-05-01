using Agate.MVC.Base;
using System.Collections.Generic;
using UnityEngine;

public class LevelStatusModel : BaseModel, ILevelStatusModel
{
    public int Level { get; protected set; }
    public List<string> LevelStatusList { get; protected set; } = new List<string> { "Unlock", "Lock", "Lock", "Lock", "Lock"};

    public void UnlockLevel(int level)
    {
        if(IsLastLevel()) return;
        
        LevelStatusList[level] = "Unlock";
    }

    public void SetLevel(int source)
    {
        Level = source;
    }

    public void Reset()
    {
        for (int i = 0; i < LevelStatusList.Count; i++)
        {
            if (i == 1)
            {
                LevelStatusList[i] = "Unlock";
            }
            LevelStatusList[i] = "Lock";
        }
    }

    public bool CheckStatus(int level)
    {
        if (LevelStatusList[level] == "Unlock")
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public bool IsLastLevel(){
        Debug.Log("Level Sekarang : " + Level);

        return Level == LevelStatusList.Count - 1;
    }
}

