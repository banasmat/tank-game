using UnityEngine;
using UnityEngine.UI;

public class ReloadBar : MonoBehaviour
{

    protected Slider slider;

    public void Start()
    {
        slider = GetComponent<Slider>();
        slider.value = 1f;
    }

    public void SetBarValue(float percentage)
    {
        slider.value = Mathf.Clamp(percentage/100, 0, 1f);
    }

}
