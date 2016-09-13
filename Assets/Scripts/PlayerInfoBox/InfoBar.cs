using UnityEngine;
using UnityEngine.UI;

public class InfoBar : MonoBehaviour
{
    protected Slider slider;

    public void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetBarValue(float percentage)
    {
        slider.value = Mathf.Clamp(percentage / 100, 0, 1f);
    }

}
