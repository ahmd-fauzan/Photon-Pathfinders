using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public struct MirrorMessage{
    public Transform mirrorTransform;
    public List<Vector3> rotateValueList;

    public MirrorMessage(Transform mirrorTransform, List<Vector3> rotateValueList){
        this.mirrorTransform = mirrorTransform;
        this.rotateValueList = rotateValueList;
    }

    public Vector3 GetNextRotate(){
        for(int i = 0; i < rotateValueList.Count; i++){
            Debug.Log(rotateValueList[i] + " == " + mirrorTransform.rotation.eulerAngles);
            if(rotateValueList[i] == this.mirrorTransform.rotation.eulerAngles){
                if(i == rotateValueList.Count-1){
                    return rotateValueList[0];
                }

                else return rotateValueList[i + 1];
            }
        }

        return Vector3.zero;
    }
}