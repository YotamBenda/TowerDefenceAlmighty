using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]

public class DragAndShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    private bool isShoot;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
       this.gameObject.transform.position = mousePressDownPos;
    }

    private void OnMouseUp()
    {
        mouseReleasePos = Input.mousePosition;
        rb.useGravity = true;
        Shoot(Force: mousePressDownPos - mouseReleasePos);
    }

    public float forceMultiplier = 3;

    void Shoot(Vector3 Force)
    {
        if (isShoot)
            return;

        rb.AddForce(new Vector3(Force.x, Force.y, z: Force.y) * forceMultiplier);
        isShoot = true;
      
    }
}
