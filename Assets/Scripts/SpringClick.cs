using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpringClick : MonoBehaviour {
    public static SpringClick Instance { get; private set; }

    [SerializeField] SpringJoint2D springJoint;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] bool connected;
    [SerializeField] float killHeight = -5.5f;

    void Awake() {
        if (!Instance) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Update() {
        lineRenderer.SetPosition(0, transform.position);
        if (Input.GetMouseButtonDown(0) && connected) {
            BreakSpring();
        }


        if (transform.position.y < killHeight) {
            SceneManager.LoadScene(0);
        }
    }
    public void SetSpringJoint(Rigidbody2D rigidbody) {
        if (!connected) {
            //spring
            Debug.Log("Set Sprung");
            springJoint.connectedBody = rigidbody;
            springJoint.enabled = true;
            StartCoroutine(ClickLockout());

            //line renderer
            Transform temp = rigidbody.gameObject.transform;
            lineRenderer.SetPosition(1, temp.position);
            lineRenderer.enabled = true;
        }
    }

    public void BreakSpring() {
        //spring
        Debug.Log("Broke Sprung");
        connected = false;
        springJoint.enabled = false;
        springJoint.connectedBody = null;

        //line renderer
        lineRenderer.SetPosition(1, transform.position);
        lineRenderer.enabled = false;
    }

    IEnumerator ClickLockout() {
        yield return new WaitForSecondsRealtime(.1f);
        connected = true;
    }
}
