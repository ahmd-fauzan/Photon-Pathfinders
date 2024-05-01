using Agate.MVC.Base;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class LevelView : ObjectView<ILevelModel>
{
    [SerializeField]
    private Button _level1;

    [SerializeField]
    private Button _level2;
    [SerializeField]
    private Button _level3;
    [SerializeField]
    private Button _level4;
    [SerializeField]
    private Button _level5;

    [SerializeField]
    private Button _onBack;

    public void Init(UnityAction<int> levelSelect, UnityAction onBack)
    {
        _level1.onClick.RemoveAllListeners();
        _level1.onClick.AddListener(() => levelSelect(1));
        _level2.onClick.RemoveAllListeners();
        _level2.onClick.AddListener(() => levelSelect(2));
        _level3.onClick.RemoveAllListeners();
        _level3.onClick.AddListener(() => levelSelect(3));
        _level4.onClick.RemoveAllListeners();
        _level4.onClick.AddListener(() => levelSelect(4));
        _level5.onClick.RemoveAllListeners();
        _level5.onClick.AddListener(() => levelSelect(5));
        _onBack.onClick.RemoveAllListeners();
        _onBack.onClick.AddListener(onBack);
    }

    protected override void InitRenderModel(ILevelModel model)
    {

    }

    protected override void UpdateRenderModel(ILevelModel model)
    {

    }
}
