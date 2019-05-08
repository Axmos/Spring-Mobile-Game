using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] Tag playerTag;
    public bool CompareTag(Tag temp) {
        return playerTag == temp;
    }
}
