using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using UnityEngine;

public class GameLauncher : SceneLauncher<GameLauncher, GameView>
{   
    public string scene = "";

    public override string SceneName {
        get{
             return scene;
        }
    }

    private GameplayController _gameplay;
    private TowerController _tower;
    private MirrorController _mirror;
    private GameoverController _gameOver;

    protected override IConnector[] GetSceneConnectors()
    {
        return new IConnector[]
        {
            new GameoverConnector(),
            new LevelConnector(),
        };
    }

    protected override IController[] GetSceneDependencies()
    {
        return new IController[]
            {
                new GameplayController(),
                new TowerController(),
                new MirrorController(),
                new GameoverController(),
                new LevelController(),
            };
    }

    protected override IEnumerator InitSceneObject()
    {
        _gameplay.SetView(_view.GameplayView);
        _tower.SetView(_view.TowerView);
        _mirror.SetView(_view.MirrorView);
        _gameOver.SetView(_view.GameOverView);

        yield return null;
    }

    protected override IEnumerator LaunchScene()
    {
        scene = Scenes.GamePlay + (_tower.Model.Level + 1);
        Debug.Log(" Register Manual Scene Launch : " + scene);
        RegisterLauncher();
        yield return null;
    }
    
}
