using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Meta.XR.MRUtilityKit;
using Unity.AI.Navigation;

public class RuntimeNavMeshBuilder : MonoBehaviour
{

    private NavMeshSurface navMeshSurface;
    // Start is called before the first frame update
    void Start()
    {
        navMeshSurface = GetComponent<NavMeshSurface>();
        MRUK.Instance.RegisterSceneLoadedCallback(BuildNavmesh);
    }

    // Update is called once per frames
    void BuildNavmesh()
    {
        StartCoroutine(BuildNavmeshRoutine());
    }

    public IEnumerator BuildNavmeshRoutine(){
        yield return new WaitForEndOfFrame();
        navMeshSurface.BuildNavMesh();
    }
}
