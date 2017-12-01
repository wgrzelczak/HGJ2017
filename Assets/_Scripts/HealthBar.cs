using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class HealthBar : MonoBehaviour
{
    public GameObject fillRect;
	private Slider slider;

	private void Start()
	{
		slider = GetComponent<Slider> ();
		slider.value = 1.0f;
	}

	public void SetValue(int currentHp, int startHp)
	{
        if (currentHp <= 0)
        {
            fillRect.SetActive(false);
        }
        else
        {
            slider.value = (float)currentHp / (float)startHp;
        }
	}
}
