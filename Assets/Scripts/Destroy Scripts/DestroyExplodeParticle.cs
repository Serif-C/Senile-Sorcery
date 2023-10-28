using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyExplodeParticle : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(DestroyParticles());
    }

    private IEnumerator DestroyParticles()
    {
        yield return new WaitForSeconds(0.2f);
        Destroy(gameObject);
    }
}
