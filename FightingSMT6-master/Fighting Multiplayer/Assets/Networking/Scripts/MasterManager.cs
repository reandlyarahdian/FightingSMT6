using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

[CreateAssetMenu(menuName = "Singleton/Master Manager", fileName ="New Master Manager")]
public class MasterManager : SingletonScriptableObject<MasterManager>
{
    [SerializeField]
    private GameSettings gameSettings;
    
    public static GameSettings GameSettings { get => Instance.gameSettings; }

    private List<NetworkPrefabs> networkPrefabs = new List<NetworkPrefabs>();

    public static GameObject NetworkInstantiate(GameObject obj, Vector3 position, Quaternion rotation)
    {
        foreach (NetworkPrefabs networkPrefabs in Instance.networkPrefabs)
        {
            if (networkPrefabs.Prefabs == obj)
            {
                if (networkPrefabs.Path != string.Empty)
                {
                    GameObject result = PhotonNetwork.Instantiate(networkPrefabs.Path, position, rotation);

                    return result;
                }

                else
                {
                    Debug.LogError("the prebas is empty for game objet name " + networkPrefabs.Prefabs);

                    return null;
                }
            }
        }

        return null;
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
    public static void PopulateNetworkPrefabs()
    {
    #if UNITY_EDITOR
        Instance.networkPrefabs.Clear();

        GameObject[] results = Resources.LoadAll<GameObject>("");

        for (int i = 0; i < results.Length; i++)
        {
            if (results[i].GetComponent<PhotonView>() != null)
            {
               string path = AssetDatabase.GetAssetPath(results[i]);

                Instance.networkPrefabs.Add(new NetworkPrefabs(results[i], path));
            }
        }
    #endif
    }
}
