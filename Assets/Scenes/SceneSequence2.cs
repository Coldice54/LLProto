using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneSequence2 : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject cam3;
    public GameObject fade;
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
        yield return new WaitForSeconds(2);
        fade.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
