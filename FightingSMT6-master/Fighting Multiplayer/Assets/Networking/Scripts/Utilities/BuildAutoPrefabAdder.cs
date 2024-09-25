#if UNITY_EDITOR
using UnityEditor.Build;
using UnityEditor.Build.Reporting;

public class BuildAutoPrefabAdder : IPreprocessBuildWithReport
{
    public int callbackOrder { get => 0; }

    public void OnPreprocessBuild(BuildReport report)
    {
        MasterManager.PopulateNetworkPrefabs();
    }
}
#endif