using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;

public class MainMenuLauncher : SceneLauncher<MainMenuLauncher, MainMenuView>
{

    private MenuController _menu;
    public override string SceneName => Scenes.MainMenu;

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
            new MenuController()
        };
    }

    protected override IEnumerator InitSceneObject()
    {
        _menu.SetView(_view.MenuView);
        yield return null;
    }

    protected override IEnumerator LaunchScene()
    {
        yield return null;
    }
}
