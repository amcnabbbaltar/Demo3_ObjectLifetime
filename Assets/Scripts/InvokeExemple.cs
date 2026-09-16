using UnityEngine;
using System.Collections;
public class InvokeExemple : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Invoke(nameof(MyFunction),3f);
        StartCoroutine(MyCouroutine2());
    }

    void MyFunction()
    {
        Debug.Log("Hello!");
    }
    public IEnumerator MyCouroutine2()
    {
        Debug.Log("MyCouroutine2 starts");
        yield return StartCoroutine(MyCouroutine());
        Debug.Log("MyCouroutine2 finished");
    }
    public IEnumerator MyCouroutine()
    {
            Debug.Log("Co routine start ");
            yield return new WaitForSeconds(3f);
            Debug.Log("Co routine stopped ");

    }
}
