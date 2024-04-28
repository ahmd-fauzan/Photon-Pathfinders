using Agate.MVC.Base;
using UnityEngine;

public class SoundEffectController : BaseController<SoundEffectController>
{
    public void LockSound(LockMessage message){
        Debug.Log("Level lock sound play");
    }
}
