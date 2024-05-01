using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Agate.MVC.Base;
using UnityEngine.UI;
using UnityEngine.Events;

public class GameoverView : ObjectView<IGameoverModel>
{
    [SerializeField] private GameObject _gameOverPopUp;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _exitGameButton;
    

    public void Init(UnityAction onRestart, UnityAction onMainMenu, UnityAction onNextLevel, UnityAction onExitGame){
        _restartButton.onClick.RemoveAllListeners();
        _restartButton.onClick.AddListener(onRestart);
        _mainMenuButton.onClick.RemoveAllListeners();
        _mainMenuButton.onClick.AddListener(onMainMenu);
        _nextLevelButton.onClick.RemoveAllListeners();
        _nextLevelButton.onClick.AddListener(onNextLevel);
        _exitGameButton.onClick.RemoveAllListeners();
        _exitGameButton.onClick.AddListener(onExitGame);
    }

     public void Show(){
        _gameOverPopUp.SetActive(true);
    }

    public void HideNextLevel(){
        _nextLevelButton.gameObject.SetActive(false);
    }

    protected override void InitRenderModel(IGameoverModel model)
    {
        
    }

    protected override void UpdateRenderModel(IGameoverModel model)
    {

    }
}
   
