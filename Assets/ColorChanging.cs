using UnityEditor;
using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    public Color[] colors;
   
    public float fadeTime = 0.5f;
    private int currentIndex = 0;
    
    private float timeSinceLastChange = 0.0f;
    private Color startColor;
    private Color endColor;

    private bool isChangingColor = false;

    void Start()
    {
        GetComponent<Renderer>().material.color = colors[0];
    }

    void Update()
    {

        if (!isChangingColor)
        {
            startColor = GetComponent<Renderer>().material.color;
            currentIndex++;
            if (currentIndex >= colors.Length)
            {
                currentIndex = 0;
            }
            endColor = colors[currentIndex];

            isChangingColor = true;
            timeSinceLastChange= 0f;


        }


        if (isChangingColor)
        {
            timeSinceLastChange += Time.deltaTime;
            float progress = Mathf.Clamp01(timeSinceLastChange / fadeTime);


            GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, progress);


            if (progress >= 1.0f)
            {
                isChangingColor = false;
            }
        }
    }
}
