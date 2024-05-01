using Agate.MVC.Base;

public class LevelConnector : BaseConnector
{
    private LevelController _level;

    protected override void Connect(){
        Subscribe<LevelMessage>(_level.NextLevel);
    }

    protected override void Disconnect(){
        Unsubscribe<LevelMessage>(_level.NextLevel);
    }
}
