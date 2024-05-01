using Agate.MVC.Base;
using System.Collections;

using UnityEngine;

public class LevelController : ObjectController<LevelController, LevelModel, ILevelModel, LevelView>
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

    public override void SetView(LevelView view)
    {
        base.SetView(view);
        view.Init(LevelSelect, Onback);
    }

    public void SetLevel(int source)
    {
        _model.SetLevel(source);
        _levelStatus.SetLevel(_model.Level);
    }

    public void LevelSelect(int number)
    {
        Debug.Log("Show Scene : " + number);
        SetLevel(number);
        bool IsUnlockResult = _levelStatus.IsUnlock(_model.Level);

        if (IsUnlockResult)
        {
            Debug.Log("Level " + _model.LevelNumber + " is unlock");
            SceneLoader.Instance.LoadScene("Level" + _model.LevelNumber);
        }
        else
        {
            Debug.Log("Level " + _model.LevelNumber + " is lock");
            Publish<LockMessage>(new LockMessage());
        }
    }

    public void NextLevel(LevelMessage message){
        int currentLevel = _model.LevelNumber;

        Debug.Log("Current Level : " + currentLevel);

        LevelSelect(currentLevel + 1);
    }

    public void Onback()
    {
        SceneLoader.Instance.LoadScene(Scenes.MainMenu);
    }
}
