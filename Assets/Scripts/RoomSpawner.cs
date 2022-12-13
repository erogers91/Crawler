using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    public int openingDirection;
    // 1 --> need botton door
    // 2 --> need top door
    // 3 --> need left door
    // 4 --> need right door

    void Update()
    {
        if(openingDirection == 1){
            // Need to spawn a room with a Bottom door
        } else if(openingDirection == 2) {
            // Need to spawn a roon with a Top door.
        } else if(openingDirection == 3) {
            // Need to spawn a room with a Left door.
        } else if(openingDirection == 4) {
            // Need to spawn a room with a Right door.
        }
    }
}
