using Agate.MVC.Base;
using System.Collections.Generic;

public interface ILevelStatusModel : IBaseModel
{
    int Level {get; }
    List<string> LevelStatusList {get; }
}
