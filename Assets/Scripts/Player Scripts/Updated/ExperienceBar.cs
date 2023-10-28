using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBar : MonoBehaviour
{
    public Slider slider;
    public Image fill;

    public void SetMaxEXP(float experience)
    {
        slider.maxValue = experience;
    }

    public void SetEXP(float experience)
    {
        slider.value = experience;
    }
}
