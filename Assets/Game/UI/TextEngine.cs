using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEngine : MonoBehaviour
{
    public string text;
    public TextSans font;
    public Color color;

    public float size;
    public float padding;

    public TextAlignment alignment = TextAlignment.Left;

    [HideInInspector]
    public float totalsize;

    private void Awake() {
        font.Translate();
        Print();
    }

    public void Print(string printable = null) {
        if(font.alphabet.Count == 0) { font.Translate(); }
        foreach(Transform child in transform) {
            Destroy(child.gameObject);
        }
        string _print = "";
        if(printable == null) {
            _print = text;
        }
        else {
            _print = printable;
        }

        float _increaser = 0f;
        foreach(char _char in _print) {
            string _string = _char.ToString();
            if(_string == " ") {
                _increaser += padding * 2 * size;
            }
            else {
                Sprite _sprite = font.alphabet[_string];
                GameObject _object = new GameObject(_string);
                _object.transform.parent = transform;
                RectTransform _comprect = _object.AddComponent<RectTransform>();
                _comprect.anchorMin = new Vector2(0f,1f);
                _comprect.anchorMax = new Vector2(0f,1f);
                _comprect.pivot = new Vector2(0f,1f);
                _comprect.sizeDelta = new Vector2(_sprite.bounds.size.x * size * _sprite.pixelsPerUnit,_sprite.bounds.size.y * size * _sprite.pixelsPerUnit);
                _comprect.anchoredPosition = new Vector3(0f + _increaser,0f,0f);
                Image _compimage = _object.AddComponent<Image>();
                _compimage.color = color;
                _compimage.sprite = _sprite;
                _increaser += _comprect.sizeDelta.x + padding;
            }
            totalsize = _increaser;
        }

        if(alignment == TextAlignment.Right) transform.localPosition = new Vector3(transform.localPosition.x - totalsize, transform.localPosition.y, transform.localPosition.z);
    }

    public enum TextAlignment {
        Left,
        Right
    }
}
