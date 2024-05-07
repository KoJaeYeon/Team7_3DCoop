using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sky : MonoBehaviour
{
    bool skyDown = true;
    private void Start()
    {
        StartCoroutine(SkyDown());
    }
    private void Update()
    {
        if(skyDown)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.up * Time.deltaTime);
        }
        
    }
    IEnumerator SkyDown()
    {
        while (true)
        {
            yield return new WaitForSeconds(10);
            skyDown = false;
            yield return new WaitForSeconds(10);
            skyDown = true;
        }
    }
}
