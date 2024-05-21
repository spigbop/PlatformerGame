using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataReader : MonoBehaviour
{
    public static string Read(string path) {
        StreamReader reader = new StreamReader(path);
        string retval = reader.ReadToEnd();
        reader.Close(); reader.Dispose();
        return retval;
    }
}
