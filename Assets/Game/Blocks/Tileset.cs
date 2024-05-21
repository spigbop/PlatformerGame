using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tileset : MonoBehaviour
{
    // Properties --
    public string Name;

    // Fields --
    [HideInInspector]
    public List<GameObject> originals = new List<GameObject>();

    public void Awake() {
        foreach(Transform child_transform in gameObject.GetComponentInChildren<Transform>()) originals.Add(child_transform.gameObject);
    }
}
