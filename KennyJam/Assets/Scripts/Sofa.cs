using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sofa : MonoBehaviour {
    public Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        //GetComponent<Rigidbody>().velocity = -Vector3.forward * 2f;
    }
}
