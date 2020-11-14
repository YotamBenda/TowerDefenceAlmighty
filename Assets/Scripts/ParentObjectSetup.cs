using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentObjectSetup : MonoBehaviour
{
    public static Transform objectLocation = null;
    private Transform self;
    
    public void SetTransform()
    {
        if(objectLocation = null)
        {
            objectLocation = gameObject.transform;
        }
        else
        {
            self = GetComponent<Transform>();
            self = objectLocation;
        }
    }
}
