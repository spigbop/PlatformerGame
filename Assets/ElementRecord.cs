using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementRecord : MonoBehaviour
{
    public static Dictionary<string,Transform> Records = new Dictionary<string,Transform>();
    public static List<Transform> RecordsListed = new List<Transform>();

    private Coroutine CurrentWorker;

    private void Awake() {
        CurrentWorker = StartCoroutine("Worker");
    }

    private IEnumerator Worker() {
        foreach(Transform child_transform in gameObject.GetComponentsInChildren<Transform>(true)) {
            Records[child_transform.gameObject.name] = child_transform;
            RecordsListed.Add(child_transform);
        }
        yield return true;
    }
}
