using Agate.MVC.Base;
using UnityEngine;

public class MirrorModel : BaseModel, IMirrorModel
{
    public bool IsFlipped { get; set; }
    public Transform MirrorRotate {get; set; }
}
