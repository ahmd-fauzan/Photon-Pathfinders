using Agate.MVC.Base;
using UnityEngine;

using System.Collections;

public class DataController : DataController<DataController, DataModel, IDataModel>
{
    public override IEnumerator Initialize(){
        yield return base.Initialize();
        //Set Data
    }

    public override IEnumerator Finalize(){
        yield return base.Finalize();
    }
}
