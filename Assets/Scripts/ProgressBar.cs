using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public float min = 0;
    public float max = 0;
    public float current = 0;
    public Image fill;
  

    // Update is called once per frame
    void Update()
    {
        FillBar();
    }

    private void FillBar()
    {
        fill.fillAmount = (current - min) / (max - min);
    }
}
