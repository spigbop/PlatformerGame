using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeldElement : MonoBehaviour
{
    private void Start() {
        Cursor.visible = false;
    }

    private void Update() {
        Vector3 worldpos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.localPosition = new Vector3(worldpos.x, worldpos.y, -9f);

        if(Input.GetMouseButtonDown(0)) {
            
        }
    }
}
