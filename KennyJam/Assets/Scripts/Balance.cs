using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VacuumBreather;

public class Balance : MonoBehaviour {
    [SerializeField] private Vector3 pidValues;
    [SerializeField] private Transform target;
    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
    }

    private float lastError = 0;

    private void Update() {
        PidController pidController = new PidController(pidValues.x, pidValues.y, pidValues.z);

        Vector3 f = Vector3.ProjectOnPlane(transform.up, transform.right);
        Vector3 tf = Vector3.ProjectOnPlane(target.up, transform.right);
        float error = Vector3.SignedAngle(f, tf, transform.right);
        float dError = error - lastError;
        float output = pidController.ComputeOutput(error, dError, Time.deltaTime);

        rb.AddTorque(transform.right * output);

        lastError = error;
    }
}
