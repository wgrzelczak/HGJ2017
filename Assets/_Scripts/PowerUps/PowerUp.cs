using UnityEngine;
using UnityEngine.UI;

public class PowerUp
{
    public Sprite icon;
    public PowerUpTypes powerUpTypes;

    public PowerUp(Sprite icon, PowerUpTypes powerUpType)
    {
        this.icon = icon;
        this.powerUpTypes = powerUpType;
    }

    public void ApplyBehavior(Player player)
    {
        switch (powerUpTypes)
        {
            case PowerUpTypes.AttackIncrease:
                player.damage += 2;
                break;
            case PowerUpTypes.SpeedIncrease:
                player.GetComponent<PlayerControl>()._velocity += 30;
                break;
            case PowerUpTypes.Freeze:
                break;
            default:
                throw new System.ArgumentOutOfRangeException();
        }
        AudioManager.GetInstance().PlaySFX(AUDIO.ITEM_COLLECT);
    }

    public void RemoveBehavior(Player player)
    {
        switch (powerUpTypes)
        {
            case PowerUpTypes.AttackIncrease:
                player.damage -= 2;
                break;
            case PowerUpTypes.SpeedIncrease:
                player.GetComponent<PlayerControl>()._velocity -= 30;
                break;
            case PowerUpTypes.Freeze:
                break;
            default:
                throw new System.ArgumentOutOfRangeException();
        }
    }
}
