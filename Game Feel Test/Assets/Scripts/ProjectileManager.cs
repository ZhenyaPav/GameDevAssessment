using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileManager : MonoBehaviour
{
    [SerializeField] private List<GameObject> projectilePrefabs;

    public void Launch(int index){
        Instantiate(projectilePrefabs[index], transform)
            .GetComponent<Projectile>()
            .Launch();
    }
}
