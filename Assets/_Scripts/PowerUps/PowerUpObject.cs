using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(BoxCollider))]
public class PowerUpObject : Collectable
{
    public Sprite icon;
    public PowerUpTypes type;

    protected override void Effect()
    {
        if (player.CollectPowerUp(new PowerUp(icon, type)))
        {
            Destroy(gameObject);
        }
    }
}
