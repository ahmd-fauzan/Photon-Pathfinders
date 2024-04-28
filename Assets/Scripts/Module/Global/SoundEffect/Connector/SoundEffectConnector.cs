using Agate.MVC.Base;

public class SoundEffectConnector : BaseConnector
{
    private SoundEffectController _soundEffect;

    protected override void Connect(){
        Subscribe<LockMessage>(_soundEffect.LockSound);
    }

    protected override void Disconnect(){
        Unsubscribe<LockMessage>(_soundEffect.LockSound);
    }
}
