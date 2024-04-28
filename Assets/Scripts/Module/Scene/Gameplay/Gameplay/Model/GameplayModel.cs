using Agate.MVC.Base;
using System.Collections.Generic;
using UnityEngine;

public class GameplayModel : BaseModel, IGameplayModel
{
    public int Level { get; protected set; }
    
    public void SetLevel(int source)
    {
        Level = source;
        SetDataAsDirty();
    }
}
