using Agate.MVC.Base;
using UnityEngine;

public class TowerModel : BaseModel, ITowerModel
{
    public LineRenderer LineShoot{ get; set; }
    public int Level {get; set;}
}
