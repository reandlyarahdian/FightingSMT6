using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class NetworkPrefabs
{
    public GameObject Prefabs;

    public string Path;

    public NetworkPrefabs(GameObject _prefabs, string _path)
    {
        Prefabs = _prefabs;
        Path = ReturnPrefabPathModified(_path);
    }

    private string ReturnPrefabPathModified(string _path)
    {
        int extensionLength = System.IO.Path.GetExtension(_path).Length;
        int additionalLength = 10;
        int startIndex = _path.ToLower().IndexOf("resources");

        if (startIndex == -1)
        {
            return string.Empty;
        }

        else
        {
            return _path.Substring(startIndex + additionalLength, _path.Length - (additionalLength + startIndex + extensionLength));
        }
    }
}
