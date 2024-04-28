using Agate.MVC.Base;
using Agate.MVC.Core;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : BaseMain<GameMain>, IMain
{
    protected override IConnector[] GetConnectors(){
        return new IConnector[]{
            new SoundEffectConnector()
        };
    }

    protected override IController[] GetDependencies(){
        return new IController[]{
            new DataController(),
            new LevelStatusController(),
            new SoundEffectController()
        };
    }

    protected override IEnumerator StartInit(){
        yield return null;
    }
}
