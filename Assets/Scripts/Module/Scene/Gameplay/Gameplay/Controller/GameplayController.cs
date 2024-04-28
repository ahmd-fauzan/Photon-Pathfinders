using Agate.MVC.Base;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class GameplayController : ObjectController<GameplayController, GameplayModel, IGameplayModel, GameplayView>
{
    private LevelStatusController _levelStatus;
    private LineRenderer _lineRenderer;
    private LayerMask layerMask;
    private LayerMask receiverLayerMask;
    private Transform receiverTransform;

    public override IEnumerator Initialize()
    {
        yield return base.Initialize();
    }

    public override IEnumerator Finalize()
    {
        yield return base.Finalize();

    }

    public override void SetView(GameplayView view){
        base.SetView(view);
        view.Init(RotateObjectCoroutine);

        int LevelSelect = _levelStatus.Model.Level;
        SetLevel(LevelSelect);
    }

    public void SetLevel(int level)
    {
        _model.SetLevel(level);
    }

    public void RotateObjectCoroutine()
    {
        Debug.Log("Rotate");
        // float elapsedTime = 0f;

        // while (elapsedTime < 1f)
        // {
        //     // Tambahkan waktu yang telah berlalu
        //     elapsedTime += Time.deltaTime;

        //     // Hitung rotasi yang diinterpolasi dari startRotation ke endRotation
        //     float rotation = Mathf.Lerp(startRotation, endRotation, elapsedTime / 1f);

        //     // Atur rotasi objek
        //     mirrorTransform.rotation = Quaternion.Euler(0f, 0f, rotation);
        // }

        // // Pastikan rotasi akhir disetel dengan benar
        // mirrorTransform.rotation = Quaternion.Euler(0f, 0f, endRotation);
    }

    IEnumerator ShowLine(float duration){
        float elapsedTime = 0f;
        float smoothValue = 0f;

        while (elapsedTime < duration)
        {
            // Tambahkan waktu yang telah berlalu
            elapsedTime += Time.deltaTime;

            // Hitung nilai smooth antara 0 dan 1 dengan lerp
            smoothValue = Mathf.Lerp(0f, 0.15f, elapsedTime / duration);

            // Gunakan nilai smooth ini untuk melakukan apa pun yang diperlukan
            Debug.Log("Smooth Show Value: " + smoothValue);

            _lineRenderer.startWidth = smoothValue;
            _lineRenderer.endWidth = smoothValue;

            yield return null;
        }
    }

    IEnumerator HideLine(float duration){
        float elapsedTime = 0f;
        float smoothValue = 0.15f;

        while (elapsedTime < duration)
        {
            // Tambahkan waktu yang telah berlalu
            elapsedTime += Time.deltaTime;

            // Hitung nilai smooth antara 0 dan 1 dengan lerp
            smoothValue = Mathf.Lerp(smoothValue, 0f, elapsedTime / duration);

            // Gunakan nilai smooth ini untuk melakukan apa pun yang diperlukan
            Debug.Log("Smooth Hide Value: " + smoothValue);

            _lineRenderer.startWidth = smoothValue;
            _lineRenderer.endWidth = smoothValue;

            yield return null;
        }
    }

    public IEnumerator DrawLineRenderer(){
        Ray2D ray = new Ray2D(receiverTransform.position, receiverTransform.up);
        RaycastHit2D hit;
        int reflections = 10;
        int maxLength = 100;

        _lineRenderer.positionCount = 1;
        _lineRenderer.SetPosition(0, receiverTransform.position);
        float remainingLength = maxLength;

        for (int i = 0; i < reflections; i++)
        {
            hit = Physics2D.Raycast(ray.origin, ray.direction, remainingLength, receiverLayerMask);

            if(hit){
                _lineRenderer.positionCount += 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, hit.point);

                break;
            }

            hit = Physics2D.Raycast(ray.origin, ray.direction, remainingLength, layerMask);

            if (hit)
            {
                _lineRenderer.positionCount += 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, hit.point);
                remainingLength -= Vector2.Distance(ray.origin, hit.point);

                // Get the reflected vector of the raycast.
                Vector2 updatedDirection = Vector2.Reflect(ray.direction, hit.normal);
                                    
                // Create new Ray object & set origin to be 0.01f away from hitpoint so the line is not colliding with the gameobject collider.
                ray = new Ray2D(hit.point + updatedDirection * 0.01f, updatedDirection);

                yield return new WaitForSeconds(.2f);

                if (hit.collider.tag != "Mirror")
                    break;
            }
            else
            {
                _lineRenderer.positionCount += 1;
                _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, ray.origin + ray.direction * remainingLength);
            }

            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(.5f);

        // StartCoroutine(HideLine(.2f));
    }

    public void Back()
    {
        SceneLoader.Instance.LoadScene(Scenes.LevelSelect);
    }
}
