using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthText : MonoBehaviour
{
    private float timelive = 0.4f;
    private float speedlive = 90f;

    public TextMesh textMesh;
    public RectTransform rTransform;

    private float timeElapsed = 0.0f;
    private Vector3 floatDirection = new Vector3(0, 1, 0);

    private void Start()
    {
        textMesh = GetComponent<TextMesh>();
        rTransform = GetComponent<RectTransform>();
    }

    private void Update()
    {
        timeElapsed += Time.deltaTime;
        rTransform.position += floatDirection*  speedlive * Time.deltaTime;
        if(timeElapsed > timelive)
        {
            Destroy(gameObject);
        }
    }
}
