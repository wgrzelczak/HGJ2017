using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUpTypes
{
    AttackIncrease,
    SpeedIncrease,
    Freeze,
}

public class PowerUpManager : MonoBehaviour
{
    public Vector3[] powerUpSpots;
    public GameObject[] powerUps;
    public int[] spotsTaken;

    private static PowerUpManager _instance;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        spotsTaken = new int[powerUpSpots.Length];
        for (int i = 0; i < spotsTaken.Length; i++)
        {
            spotsTaken[i] = 0;
        }
        StartCoroutine(GeneratePowerUps());
    }

    public static PowerUpManager GetInstance()
    {
        return _instance;
    }

    private IEnumerator GeneratePowerUps()
    {
        float minTime = 15.0f;
        float maxTime = 30.0f;
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            InstantiatePowerUp();
        }
    }

    private void InstantiatePowerUp()
    {
        int spot = Random.Range(0, powerUpSpots.Length);
        int powerUp = Random.Range(0, powerUps.Length);
        print(spot);
        if (spotsTaken[spot] == 0)
        {
            if (spot % 2 == 0)
            {
                Instantiate(powerUps[powerUp], powerUpSpots[spot], Quaternion.Euler(90.0f, 0.0f, 0.0f));
                Instantiate(powerUps[powerUp], powerUpSpots[spot + 1], Quaternion.Euler(90.0f, 0.0f, 0.0f));
                spotsTaken[spot] = 1;
                spotsTaken[spot + 1] = 1;
            }
            else
            {
                Instantiate(powerUps[powerUp], powerUpSpots[spot], Quaternion.Euler(90.0f, 0.0f, 0.0f));
                Instantiate(powerUps[powerUp], powerUpSpots[spot - 1], Quaternion.Euler(90.0f, 0.0f, 0.0f));
                spotsTaken[spot] = 1;
                spotsTaken[spot - 1] = 1;
            }
        }
        AudioManager.GetInstance().PlaySFX(AUDIO.ITEM_SPAWN);
    }
}
