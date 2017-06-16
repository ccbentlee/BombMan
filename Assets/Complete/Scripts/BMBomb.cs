using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BMBomb : MonoBehaviour
{
    public float delayTime = 1f;
    public GameObject explodeParticlePrefab;

    void Start()
    {
        Invoke("Explode", delayTime);
    }

    void Explode()
    {
        var go = Instantiate(explodeParticlePrefab, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
