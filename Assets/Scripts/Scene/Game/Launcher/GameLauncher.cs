using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;

public class GameLauncher : SceneLauncher<GameLauncher, GameView>
{
    public override string SceneName => Scenes.GamePlay;
    private GameplayController _gameplay;
    private TowerController _tower;
    private MirrorController _mirror;

    protected override IConnector[] GetSceneConnectors()
    {
        return new IConnector[]
        {

        };
    }

    protected override IController[] GetSceneDependencies()
    {
        return new IController[]
            {
                new GameplayController(),
                new TowerController(),
                new MirrorController(),
            };
    }

    protected override IEnumerator InitSceneObject()
    {
        _gameplay.SetView(_view.GameplayView);
        _tower.SetView(_view.TowerView);
        _mirror.SetView(_view.MirrorView);
        
        yield return null;
    }

    protected override IEnumerator LaunchScene()
    {
        yield return null;
    }
    
}
