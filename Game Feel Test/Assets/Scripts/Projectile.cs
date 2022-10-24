using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.VFX;

public class Projectile : MonoBehaviour
{
    public float speed = 10;
    Rigidbody _RB;
    public float waitTime = 2f;

    [SerializeField] private CinemachineImpulseSource impulseSource;
    [SerializeField] private float launchImpulseForce = 1f, impactImpulseForce = 3f;

    [SerializeField] private GameObject trailParticles;
    [SerializeField] private GameObject explosionPrefab;
    private void Awake()
    {
        _RB = GetComponent<Rigidbody>();        
        if(!impulseSource) impulseSource = GetComponent<CinemachineImpulseSource>();
    }
    public void Launch() => Launch(.5f);
    public void Launch(float delay) => StartCoroutine(LaunchAnimation(delay));
    private IEnumerator LaunchAnimation(float delay = .5f){
        if(impulseSource) impulseSource.GenerateImpulse(launchImpulseForce);
        if(trailParticles) trailParticles.SetActive(true);
        yield return new WaitForSeconds(delay);
        _RB.velocity = new Vector3(0, 0, -speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(impulseSource) impulseSource.GenerateImpulse(impactImpulseForce);
        if(explosionPrefab) Instantiate(explosionPrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
