using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshDeformerInput : MonoBehaviour
{
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            HandleIput();
        }
    }

    void HandleIput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(inputRay,out hit))
        {
            TouchCell(hit.point);
        }
    }

    void TouchCell(Vector3 position)
    {
        position = transform.InverseTransformDirection(position);
        Debug.Log("touched at" + position);
    }

}
