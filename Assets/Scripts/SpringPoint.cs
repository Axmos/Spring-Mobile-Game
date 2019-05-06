using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPoint : MonoBehaviour {
    [SerializeField] Rigidbody2D rb;
    void OnMouseDown() {
        Debug.Log("OnMouseDowned");
        SpringClick.Instance.SetSpringJoint(rb);
    }
}
