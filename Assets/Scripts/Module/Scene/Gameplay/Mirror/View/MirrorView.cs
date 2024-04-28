using Agate.MVC.Base;
using UnityEngine.Events;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MirrorView : ObjectView<IMirrorModel>
{
    [SerializeField] private LayerMask layer;

    private UnityAction<MirrorMessage> _rotateAction;

    public void Init(UnityAction<MirrorMessage> rotateMirror){
        _rotateAction = rotateMirror;
        // mirrorClick.onClick.AddListener(rotateMirror);
    }

    protected override void InitRenderModel(IMirrorModel model)
    {
        
    }

    protected override void UpdateRenderModel(IMirrorModel model)
    {
        
    }

    void Update(){
        if (Input.GetMouseButtonUp(0)){
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero, Mathf.Infinity, layer);

            if (hit.collider != null)
            {
                _rotateAction?.Invoke(new MirrorMessage(hit.collider.transform.parent, new List<Vector3>{new Vector3(0, 0, 60f), new Vector3(0, 0, 300f)}));
            }
        }
        
    }
}
