using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable()]
public enum TEAM
{
    RED,
    BLUE
}

public enum ACTION
{
    SKILL_1,
    SKILL_2,
    SKILL_3,
    SKILL_4
}

public class Player : MonoBehaviour
{
    public TEAM team;
    public Image powerUpIcon;
    public PowerUpTimer powerUpTimer;
    Doors doors;

    public int damage = 10;

    private PowerUp powerUp;
    private bool powerUpActive = false;

    private void Start()
    {
        doors = TeamManager.GetInstance().GetDoors(team);
        powerUpIcon.GetComponent<CanvasRenderer>().SetAlpha(0);
        //print(doors.name);
    }

    private void Update()
    {
        //Debug.Log(damage);
    }

    public void Action(ACTION action)
    {
        switch (action)
        {
            case ACTION.SKILL_1:
                Hit();
                break;
            case ACTION.SKILL_2:
                if (!powerUpActive)
                {
                    ActivatePowerUp();
                }
                break;
            case ACTION.SKILL_3:
                break;
            case ACTION.SKILL_4:
                break;
        }
    }

    public bool CollectPowerUp(PowerUp powerUp)
    {
        if (this.powerUp == null)
        {
            this.powerUp = powerUp;
            powerUpIcon.GetComponent<CanvasRenderer>().SetAlpha(255);
            powerUpIcon.sprite = powerUp.icon;
            return true;
        }
        return false;
    }

    private void Hit()
    {
        if (Vector3.Distance(doors.transform.position, transform.position) < 1.0f)
        {
            if (!doors.areDestroyed)
            {
                //print("player hit");
                doors.Hit(damage);
            }
        }
    }

    private void ActivatePowerUp()
    {
        if (powerUp != null)
        {
            powerUpTimer.ActivateTimer(10.0f);
            powerUp.ApplyBehavior(this);
            powerUpActive = true;
        }
    }

    public void DeactivatePowerUp()
    {
        powerUp.RemoveBehavior(this);
        powerUp = null;
        powerUpActive = false;
    }
}