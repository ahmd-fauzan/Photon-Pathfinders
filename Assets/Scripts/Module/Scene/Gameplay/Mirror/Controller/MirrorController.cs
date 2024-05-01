using System.Collections;
using UnityEngine;
using Agate.MVC.Base;

public class MirrorController : ObjectController<MirrorController, MirrorModel, IMirrorModel, MirrorView>
{
    public override IEnumerator Finalize()
    {
        yield return base.Finalize();
    }

    public override void SetView(MirrorView view)
    {
        base.SetView(view);
        view.Init(RotateMirror);
    }

    public void RotateMirror(MirrorMessage message)
    {
        message.mirrorTransform.rotation = Quaternion.Euler(message.GetNextRotate());
    }
}
