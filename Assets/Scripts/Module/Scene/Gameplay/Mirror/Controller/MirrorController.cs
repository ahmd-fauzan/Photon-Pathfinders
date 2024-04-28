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
        Debug.Log("Run Mirror View : " + view.name);
        base.SetView(view);
        view.Init(RotateMirror);
    }

    public void RotateMirror(MirrorMessage message)
    {

        Debug.Log("Rotate : " + message.mirrorTransform.name);
        message.mirrorTransform.rotation = Quaternion.Euler(message.GetNextRotate());

        // if(!_model.IsFlipped)
        //     rotateTrans.rotation = Quaternion.Euler(0, 0, 60);
        // else{
        //     rotateTrans.rotation = Quaternion.Euler(0, 0, -60);
        // }

        // _model.IsFlipped = !_model.IsFlipped;
        // float startRotation = 60f;
        // float endRotation = -60f;

        // float elapsedTime = 0f;

        // while (elapsedTime < 1f)
        // {
        //     // Tambahkan waktu yang telah berlalu
        //     elapsedTime += Time.deltaTime;

        //     Debug.Log("Elapsed Time : " + elapsedTime);

        //     // Hitung rotasi yang diinterpolasi dari startRotation ke endRotation
        //     float rotation = Mathf.Lerp(startRotation, endRotation, elapsedTime / 1f);

        //     // Atur rotasi objek
        //     mirrorTransform.rotation = Quaternion.Euler(0f, 0f, rotation);
        // }

        // // Pastikan rotasi akhir disetel dengan benar
        // mirrorTransform.rotation = Quaternion.Euler(0f, 0f, endRotation);
    }
}
