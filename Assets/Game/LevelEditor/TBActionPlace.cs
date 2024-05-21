using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TBActionPlace : MonoBehaviour
{
    public Transform CrampingObject;

    private void Update() {
        if(Input.GetMouseButtonDown(0)) {
            Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            PlaceElement(ElementRecord.Records[Toolbox.selectedelement], mousepos, new Quaternion(0f, 0f, 0f, 0f));
        }
    }

    private void PlaceElement(Transform original, Vector3 position, Quaternion rotation) {
        Vector3 _position = new Vector3(0f, 0f, 0f);
        
        if(Toolbox.SnapToGrid) { _position = new Vector3(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y), 0f); }
        else { _position = position; }

        // Depth stuff (Implement)

        Transform _object = Instantiate(original, _position, rotation, transform);
        _object.gameObject.name = original.gameObject.name;

        // Add Element Clamping
        if(!Toolbox.ElementCramping) { 
            Transform _elecramp = Instantiate(CrampingObject, new Vector3(0f,0f,0f), new Quaternion(0f,0f,0f,0f), _object);
            _elecramp.gameObject.GetComponent<ElementCramping>().CheckCramping();
        }
    }
}
