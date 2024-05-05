using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particle : MonoBehaviour
{
    private void OnEnable()
    {
        StartCoroutine(Enable());
    }

    private IEnumerator Enable()
    {
        yield return new WaitForSeconds(3.0f);
        gameObject.SetActive(false);
    }
    
}
