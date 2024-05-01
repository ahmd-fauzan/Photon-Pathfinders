using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;

public class GameoverController : ObjectController<GameoverController, GameoverModel, IGameoverModel, GameoverView>
{
    private LevelStatusController _levelStatus;

    public void OnGameOver(GameoverMessage message){
        _view.Init(OnRestart, OnToMainMenu, OnNextLevel, OnExitGame);
        _view.Show();
        if(_levelStatus.Model.IsLastLevel()){
            _view.HideNextLevel();
        }
    }

    public void OnRestart(){
        SceneLoader.Instance.RestartScene();
    }

    public void OnToMainMenu(){
        SceneLoader.Instance.LoadScene(Scenes.MainMenu);
    }

    public void OnExitGame(){
        Application.Quit();
    }

    public void OnNextLevel(){
        Publish<LevelMessage>(new LevelMessage());
    }
}
