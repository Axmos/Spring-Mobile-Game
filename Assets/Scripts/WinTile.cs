using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTile : MonoBehaviour {
    [SerializeField] GameEvent WinLevel;
    [SerializeField] Tag playerTag;

    private void OnTriggerEnter2D(Collider2D col) {
        Player temp = col.GetComponent<Player>();
        if (temp) {
            if(temp.CompareTag(playerTag)) {
                WinLevel.Raise();
            }
        }
    }
}
