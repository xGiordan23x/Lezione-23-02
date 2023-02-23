using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanging : MonoBehaviour
{
    public Color[] colors; 
    public float cycleTime = 1.0f; 
    public float fadeTime = 0.5f;
    private int currentIndex = 0;
    private float timeSinceLastCycle = 0.0f; 
    private Color startColor; 
    private Color endColor; 
    private float timeSinceLastChange = 0.0f;
    private bool isChangingColor = false; 

    void Start()
    {        
        GetComponent<Renderer>().material.color = colors[0];
    }

    void Update()
    {
       
        if (!isChangingColor)
        {
           
            timeSinceLastCycle += Time.deltaTime;

            
            if (timeSinceLastCycle >= cycleTime)
            {
                
                timeSinceLastCycle = 0.0f;

                
                startColor = GetComponent<Renderer>().material.color;
                currentIndex++;
                if (currentIndex >= colors.Length)
                {
                    currentIndex = 0;
                }
                endColor = colors[currentIndex];

                
                isChangingColor = true;
                timeSinceLastChange = 0.0f;
            }
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
