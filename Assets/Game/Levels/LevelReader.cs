using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelReader : MonoBehaviour
{
    [HideInInspector]
    public List<LevelElement> elements = new List<LevelElement>();

    public void Start() {
        SendReadRequest();
    }

    public bool SendReadRequest() {
        StartCoroutine("Worker");
        return true;
    }

    private IEnumerator Worker() {
        // Read
        string leveldata = DataReader.Read(@"C:\Users\spigbop\Desktop\examplelevel.level");

        string[] rawelements = leveldata.Split(';');
        foreach(string elestring in rawelements) {
            LevelElement element = new LevelElement();

            element.rawdata  = elestring;

            string dataready = elestring.Replace("[", String.Empty);
            dataready        = dataready.Replace("]", String.Empty);

            string[] datas   = dataready.Split(',');
            foreach(string dat in datas) {
                string[] datliteral = dat.Split(':');
                element.data[datliteral[0]] = datliteral[1];
            }

            elements.Add(element);
        }

        // Instantiate
        foreach(LevelElement element in elements) {
            float posx = float.Parse(element.data["posx"]);
            float posy = float.Parse(element.data["posy"]);
            float posz = float.Parse(element.data["posz"]);

            Transform printresult = GameObject.Instantiate(ElementRecord.Records[element.data["original"]], new Vector3(posx, posy, posz), new Quaternion(0f, 0f, 0f, 0f), transform);
            printresult.gameObject.name = element.rawdata;
        }

        yield return true;
    }
}

[System.Serializable]
public class LevelElement {
    public string                    rawdata;
    public Dictionary<string,string> data = new Dictionary<string,string>();

    // ✅ Rudamentry Fields --
    // ✅ original (string)
    // ✅ posx (float)
    // ✅ posy (float)
    // ✅ posz (float)

    // Rotational Fields (Optional) --
    // rotx (float: 0.0f)
    // roty (float: 0.0f)
    // rotz (float: 0.0f)
    // rotw (float: 0.0f)

    // AI Fields --
    // ai_direction (default, left, right, random: default)
    // ai_enablemoving (bool: true)
    // ai_enableidleanimations (bool: true)
    // ai_enabledamaging (bool: true)
    // ai_conversation (string: null)
    // ai_hitboxishurtbox (bool: false)

    // Skinned Elements --
    // skin (string: null)
}
