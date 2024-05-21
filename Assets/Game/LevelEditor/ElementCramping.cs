using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ElementCramping : MonoBehaviour
{
    public void CheckCramping() {
        BoxCollider2D bxcollider = gameObject.GetComponent<BoxCollider2D>();
        ContactFilter2D cfilter = new ContactFilter2D();
        cfilter.useTriggers = true;
        List<Collider2D> cresults = new List<Collider2D>();
        //if(Physics2D.OverlapCollider(bxcollider,cfilter,cresults) > 0) Debug.Log("as");
    }
}
