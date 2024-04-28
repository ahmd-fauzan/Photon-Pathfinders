using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MenuView : BaseView
{
    [SerializeField]
    private Button _playButton;

    [SerializeField]
    private Button _exitButton;

    public void Init(UnityAction onPlay, UnityAction onExit)
    {
        _playButton.onClick.RemoveAllListeners();
        _playButton.onClick.AddListener(onPlay);
        _exitButton.onClick.RemoveAllListeners();
        _exitButton.onClick.AddListener(onExit);
    }
}
