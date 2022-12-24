using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        collision.GetComponent<Player>().hasKey = true;
        UI.instance.ToggleKeyIcon(true);
        Destroy(gameObject);
    }
}
