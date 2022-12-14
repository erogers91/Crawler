using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PickupType
{
    Coin,
    Health,
    Key
}

public class PickUp : MonoBehaviour
{
    public PickupType type;
    public int value = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (type == PickupType.Coin)
            {
                other.GetComponent<Player>().AddCoins(value);
                Destroy(gameObject);
            }
            else if (type == PickupType.Health)
            {
                bool consuming = other.GetComponent<Player>().AddHealth(value);
                if(consuming)
                    Destroy(gameObject);
            }
        }
    }
}
