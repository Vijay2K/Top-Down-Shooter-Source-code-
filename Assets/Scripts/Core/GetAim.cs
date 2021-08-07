using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetAim : MonoBehaviour
{
    [SerializeField] private GameObject crossHair = null;
    [SerializeField] private bool isCursorVisible = true;
    [SerializeField] private LayerMask layerMask;

    private Camera mainCam;


    private void Start() {
        Cursor.visible = isCursorVisible;
        mainCam = Camera.main;
    }
    
    private void FixedUpdate() {
        Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, layerMask)) {
            crossHair.transform.position = hit.point;
        }
    }
}
