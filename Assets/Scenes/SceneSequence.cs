using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSequence : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    void Start()
    {
        StartCoroutine(TheSequence());
    }


    IEnumerator TheSequence ()
    {
        yield return new WaitForSeconds(10);
        cam2.SetActive(true);
        cam1.SetActive(false);
        yield return new WaitForSeconds(2);
        cam3.SetActive(true);
        cam2.SetActive(false);
    }

}
