using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LancerScript : MonoBehaviour
{
    [SerializeField] private float scaleTimer = 0f;
    private bool isScaleUp = false;
    [SerializeField] private float scaleDuration = 0.5f;
    
    private Vector3 originalScale;
    private Vector3 targetScale = new Vector3 (2, 2, 2);
    private Coroutine saveCoroutine;
    void Start()
    {
        originalScale = transform.localScale;
    }

    IEnumerator ScaleUp()
    {
        originalScale = transform.localScale;
        Debug.Log("going up");
        targetScale = Vector3.one * 2f;
        float elapsedTime = 0f;
        while (elapsedTime < scaleDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / scaleDuration);

            elapsedTime += Time.deltaTime;

            yield return null;
        }

        transform.localScale = targetScale;
        Debug.Log("done scaling");
    }

    IEnumerator ScaleDown()
    {
        originalScale = transform.localScale;
        Debug.Log("going down");
        targetScale = Vector3.one;
        float elapsedTime = 0f;
        while (elapsedTime < scaleDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / scaleDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale = targetScale;
        Debug.Log("done scaling");
    }

    void Update()
    {
        //neu nhan thi thu nho
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (saveCoroutine != null)
            {
                StopCoroutine(saveCoroutine);
            }
            saveCoroutine = StartCoroutine(ScaleDown());
        }
        //tha ra thi phong to + nhun nhay
        if (Input.GetKeyUp(KeyCode.Space))
        {

            if (saveCoroutine != null)
            {
                StopCoroutine(saveCoroutine);
            }
            saveCoroutine = StartCoroutine(ScaleUp());
        }
    }
}
