using System.Collections;
using UnityEngine;
using Agate.MVC.Base;

public class TowerController : ObjectController<TowerController, TowerModel, ITowerModel, TowerView>{
    public override IEnumerator Finalize()
    {
        yield return base.Finalize();
    }

    public override void SetView(TowerView view)
    {
        Debug.Log("Run Tower View");
        base.SetView(view);
        view.Init(AddLine, UpdateLine, UpdateWidthLine);
        SetLineShoot(view.GetComponent<LineRenderer>());
    }

    public void SetLineShoot(LineRenderer line){
        _model.LineShoot = line;
    }

    public void AddLine(Vector3 position){
        _model.LineShoot.positionCount += 1;
        _model.LineShoot.SetPosition(_model.LineShoot.positionCount - 1, position);
    }

    public void UpdateLine(TowerMessage message){
        _model.LineShoot.positionCount = message.countLine;
        _model.LineShoot.SetPosition(message.indexLine, message.positionLine);
    }

    public void UpdateWidthLine(float value){
        _model.LineShoot.startWidth = value;
        _model.LineShoot.endWidth = value;
    }

}