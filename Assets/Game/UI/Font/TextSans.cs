using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextSans : MonoBehaviour
{
    public Dictionary<string,Sprite> alphabet = new Dictionary<string,Sprite>();

    public void Translate(bool log = false) {
        alphabet.Clear();
        foreach(Transform child in transform) {
            alphabet.Add(child.gameObject.name, child.gameObject.GetComponent<SpriteRenderer>().sprite);
        }
        if(log) {
            int i = 0;
            foreach(KeyValuePair<string, Sprite> entry in alphabet) {
                Debug.Log($"{gameObject.name} Recognized {entry.Key}");
                i++;
            }
            Debug.Log($"{i} characters Recognized ---");
        }
    }
}
