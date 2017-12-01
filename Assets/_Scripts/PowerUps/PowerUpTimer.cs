using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class PowerUpTimer : MonoBehaviour
{
    public GameObject timerObject;
	private Image timerImage;

	public float currentDuration = 0.0f;
	public float targetDuration = 10.0f;

    public Player player;

    private bool finished = true;

	private void Start()
	{
		timerImage = GetComponent<Image>();
        timerObject.SetActive(false);
	}

	private void Update()
	{
        if (finished)
            return;
        
		currentDuration += Time.deltaTime;
		if (currentDuration < targetDuration)
		{
            float newScale = currentDuration / targetDuration;
            timerObject.transform.localScale = new Vector2(1.0f - newScale, 1.0f);
		}
		else
		{
            if (player != null)
            {
                player.DeactivatePowerUp();
            }
            finished = true;
            timerObject.SetActive(false);
            timerImage.sprite = null;
            timerImage.GetComponent<CanvasRenderer>().SetAlpha(0);
		}
	}

    public void ActivateTimer(float targetDuration)
    {
        finished = false;
        currentDuration = 0.0f;
        this.targetDuration = targetDuration;
        timerObject.SetActive(true);
        timerObject.transform.localScale = new Vector2(1.0f, 1.0f);
    }
}