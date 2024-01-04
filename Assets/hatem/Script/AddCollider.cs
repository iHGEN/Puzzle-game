using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddCollider : MonoBehaviour {
    
    public  GameObject[] _object;
    public void add_collider()
    {
        if (_object.Length > 0)
        {
            for (int x = 0; x < _object.Length; x++)
            {
                Transform[] childObject = _object[x].GetComponentsInChildren<Transform>();
                for (int i = 0; i < childObject.Length; i++)
                {
                    if (childObject[i].gameObject.GetComponent<MeshFilter>() != null && childObject[i].gameObject.GetComponent<MeshCollider>() == null)
                    {
                        childObject[i].gameObject.AddComponent<MeshCollider>();
                    }
                }
            }
            return;
        }
        Debug.LogError("You did't assign object in the inspector to add Collider to it");
    }
    public void Delete_collider()
    {
        if (_object.Length > 0)
        {
            for (int x = 0; x < _object.Length; x++)
            {
                Transform[] childObject = _object[x].GetComponentsInChildren<Transform>();
                for (int i = 0; i < childObject.Length; i++)
                {
                    if (childObject[i].gameObject.GetComponent<MeshFilter>() != null && childObject[i].gameObject.GetComponent<MeshCollider>() != null)
                    {
                        DestroyImmediate(childObject[i].gameObject.GetComponent<MeshCollider>());
                    }
                }
            }
            return;
        }
        Debug.LogError("You did't assign object in the inspector to add Collider to it");
    }
}
