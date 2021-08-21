using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {

    [SerializeField] private Sofa sofa;
    [SerializeField] private Enums.Side side;
    [SerializeField] Transform model;
    [SerializeField] float radius;

    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();

        if (side == Enums.Side.left)
            PlayerInput.rollEvent_L += PlayerInput_rollEvent;
        else
            PlayerInput.rollEvent_R += PlayerInput_rollEvent;
    }

    //private void Update() {
    //    float angvel = transform.InverseTransformVector(rb.velocity).z / radius;
    //    model.localRotation = Quaternion.Euler(model.localRotation.eulerAngles + new Vector3(100 * Time.deltaTime, 0, 0));
    //    //model.Rotate(Vector3.right * angvel * Mathf.Rad2Deg, Space.Self);
    //    //model.Rotate(model.right * angvel * Mathf.Rad2Deg);
    //}

    private void PlayerInput_rollEvent(float value) {
        //rb.AddTorque(transform.right * value * 10000);
        Debug.Log(value);

        StartCoroutine(ForceOverTtime(-value, 0.5f));
    }

    private IEnumerator ForceOverTtime(float force, float time) {

        Vector3 forward = Vector3.ProjectOnPlane(sofa.transform.forward, Vector3.up).normalized;
        if (rb.velocity.magnitude < 0.3f)
            rb.velocity += forward * 0.3f;

        while (time > 0) {
            yield return new WaitForFixedUpdate();
            time -= Time.deltaTime;
            rb.AddForce(forward * force * 15000);
        }

        yield return null;
    }
}
