using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateNetworkTest : MonoBehaviour
{
    [SerializeField]
    private GameObject playerPrefab;

    private void Awake()
    {
        MasterManager.NetworkInstantiate(playerPrefab, transform.position, Quaternion.identity);
    }
}
