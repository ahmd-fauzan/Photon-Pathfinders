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
    private Button _onBack;

    public void Init(UnityAction<int> levelSelect, UnityAction onBack)
    {
        _level1.onClick.RemoveAllListeners();
        _level1.onClick.AddListener(() => levelSelect(1));
        _level2.onClick.RemoveAllListeners();
        _level2.onClick.AddListener(() => levelSelect(2));
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
