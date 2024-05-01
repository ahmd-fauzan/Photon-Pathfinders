using Agate.MVC.Base;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameplayController : ObjectController<GameplayController, GameplayModel, IGameplayModel, GameplayView>
{
    private LevelStatusController _levelStatus;

    public override IEnumerator Initialize()
    {
        yield return base.Initialize();
    }

    public override IEnumerator Finalize()
    {
        yield return base.Finalize();
    }

    public override void SetView(GameplayView view){
        base.SetView(view);
        view.Init();

        int LevelSelect = _levelStatus.Model.Level;
        SetLevel(LevelSelect);
    }

    public void SetLevel(int level)
    {
        _model.SetLevel(level);
    }

    

    public void Back()
    {
        SceneLoader.Instance.LoadScene(Scenes.LevelSelect);
    }
}
