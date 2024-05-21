using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Toolbox : MonoBehaviour
{
    public static SpriteRenderer HeldElement;
    
    public SpriteRenderer DefaultHeldElement;
    public bool DefaultSnapToGrid = true;
    public bool DefaultElementCramping = false;

    public static string selectedelement {
        get { return _selectedele; }
        set { _selectedele = value; UpdateHeldElement(); } }
    private static string _selectedele;

    // Settings --
    public static bool SnapToGrid {
        get { return _snaptogrid; }
        set { _snaptogrid = value; UpdateSnapSettingVisual(); } }
    private static bool _snaptogrid;

    public static bool ElementCramping {
        get { return _elementcramping; }
        set { _elementcramping = value; UpdateElementCrampingVisual(); } }
    private static bool _elementcramping;

    private void Start() {
        HeldElement = DefaultHeldElement;
        selectedelement = "Ground_0";

        SnapToGrid = DefaultSnapToGrid;
        ElementCramping = DefaultElementCramping;
    }

    public static void UpdateHeldElement() {
        Sprite _sprite = ElementRecord.Records[selectedelement].gameObject.GetComponent<SpriteRenderer>().sprite;
        HeldElement.sprite = _sprite;
    }

    public static void UpdateSnapSettingVisual() {}
    public static void UpdateElementCrampingVisual() {}

    private void Update() {
        if(Input.GetKeyDown(KeyCode.G)) SnapToGrid = !SnapToGrid;
        if(Input.GetKeyDown(KeyCode.Equals)) ElementCramping = !ElementCramping;
    }
}
