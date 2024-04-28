using Agate.MVC.Base;
using System.Collections;

public class LevelStatusController : DataController<LevelStatusController, LevelStatusModel, ILevelStatusModel>
{
    public override IEnumerator Initialize()
    {
        yield return base.Initialize();
    }

    public override IEnumerator Finalize()
    {
        yield return base.Finalize();

    }

    public bool IsUnlock(int level)
    {
        return _model.CheckStatus(level);
    }

    public void Unlock(int level)
    {
        _model.UnlockLevel(level);
    }

    public void Reset()
    {
        _model.Reset();
    }

    public void SetLevel(int level)
    {
        _model.SetLevel(level);
    }
}
