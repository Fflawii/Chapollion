using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AgeSlider : MonoBehaviour
{
    [SerializeField] public TextMeshProUGUI sliderText = null;

    [SerializeField] private float maxSliderAmount = 20f;

    public void SliderChange(float value)
    {
        float localValue = value * maxSliderAmount;
        sliderText.text = localValue.ToString("0");
    }
}
