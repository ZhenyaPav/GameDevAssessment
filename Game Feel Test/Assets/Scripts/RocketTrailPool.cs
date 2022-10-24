using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class RocketTrailPool : MonoBehaviour
{
    [SerializeField] float emitInterval = .1f;
    [SerializeField] private GameObject prefab;
    private ObjectPool<GameObject> pool;
    void Awake()
    {
        pool = new ObjectPool<GameObject>(InstantiateObject);
    }
    private GameObject InstantiateObject(){
        var o = Instantiate(prefab, transform);
        return o;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
