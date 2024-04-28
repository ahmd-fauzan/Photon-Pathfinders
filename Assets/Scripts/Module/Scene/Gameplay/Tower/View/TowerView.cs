using UnityEngine;
using UnityEngine.Events;
using Agate.MVC.Base;
using System.Collections;

public class TowerView : ObjectView<ITowerModel>
{
    [SerializeField] private LayerMask layer;

    private UnityAction<Vector3> _addLineAction;
    private UnityAction<TowerMessage> _updateLineAction;
    private UnityAction<float> _updateWidthAction;

    public void Init(UnityAction<Vector3> addLine, UnityAction<TowerMessage> updateLine, UnityAction<float> updateWidthLine)
    {
        _addLineAction = addLine;
        _updateLineAction = updateLine;
        _updateWidthAction = updateWidthLine;
    }

    protected override void InitRenderModel(ITowerModel model)
    {
        
    }

    protected override void UpdateRenderModel(ITowerModel model)
    {

    }

    void Update(){
        if (Input.GetMouseButtonUp(0)){
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layer);

            if (hit.collider != null)
            {
                Debug.Log("Hit : " + hit.collider.name);

                StartCoroutine(ShowLine(1));
                StartCoroutine(DrawLineRenderer());
            }
        }
    }

    private IEnumerator CallDelay(float timeDelay, UnityAction action){
        yield return new WaitForSeconds(timeDelay);

        action?.Invoke();
    }

    private IEnumerator ShowLine(float duration){
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

            _updateWidthAction?.Invoke(smoothValue);

            yield return null;
        }
    }

    IEnumerator DrawLineRenderer(){
        Ray2D ray = new Ray2D(transform.position, transform.up);
        RaycastHit2D hit;
        int reflections = 10;
        int maxLength = 100;

        _updateLineAction?.Invoke(new TowerMessage(1, 0, transform.position));
        
        float remainingLength = maxLength;

        for (int i = 0; i < reflections; i++)
        {
            hit = Physics2D.Raycast(ray.origin, ray.direction, remainingLength, 1 << 7);

            if(hit){
                
                _addLineAction?.Invoke(hit.point);

                Debug.Log("Level Finished");
                break;
            }

            hit = Physics2D.Raycast(ray.origin, ray.direction, remainingLength, 1 << 6);

            if (hit)
            {
                _addLineAction?.Invoke(hit.point);

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
                _addLineAction?.Invoke(ray.origin + ray.direction * remainingLength);
            }


            yield return new WaitForEndOfFrame();
        }

        yield return new WaitForSeconds(.5f);
        StartCoroutine(HideLine(1f));
    }

    private IEnumerator HideLine(float duration){
        float elapsedTime = 0f;
        float smoothValue = 0.15f;

        while (elapsedTime < duration)
        {
            // Tambahkan waktu yang telah berlalu
            elapsedTime += Time.deltaTime;

            // Hitung nilai smooth antara 0 dan 1 dengan lerp
            smoothValue = Mathf.Lerp(smoothValue, 0f, elapsedTime / duration);

            // Gunakan nilai smooth ini untuk melakukan apa pun yang diperlukan
            _updateWidthAction?.Invoke(smoothValue);

            yield return null;
        }
    }
}