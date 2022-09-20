using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskObject : MonoBehaviour,IDeskObject
{
    Vector3 targetScale;
    float timeScale;
    bool isScaling = false;
    public void Rotate()
    {
        
    }

    public void Scale(Vector3 targetScale,float timeScale)
    { 
        this.targetScale = targetScale;
        this.timeScale = timeScale;
    }

    IEnumerator ScaleAnimation(Vector3 targetScale, float timeScale)
    {
        isScaling = true;
        int i = 0;
        Vector3 currentScale = this.transform.localScale;
        float t = 0f;
        while (currentScale != targetScale)
        {
            if (i > 1000)
            {
                break;
            }
            t += Time.deltaTime*timeScale;
            transform.localScale = Vector3.Lerp(currentScale, targetScale, t);
            Debug.Log(currentScale);
            yield return new WaitForEndOfFrame();
            i++;
        }
        isScaling = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isScaling)
        {
            StartCoroutine(ScaleAnimation(targetScale, timeScale));
        } 
    }
}
