using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {

    [SerializeField] private Transform sofa;
    [SerializeField] private Enums.Side side;

    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        PlayerInput.rollEvent += PlayerInput_rollEvent;
    }

    private void PlayerInput_rollEvent(float value) {
        //rb.AddTorque(transform.right * value * 10000);
        Debug.Log(value);

        //Vector3 forward = Vector3.ProjectOnPlane(sofa.forward, Vector3.up).normalized;
        //rb.AddForce(forward * value * 10000);

        if (side == Enums.Side.left && Input.GetKey(KeyCode.Q))
            StartCoroutine(ForceOverTtime(-value, 0.5f));
        else if (side == Enums.Side.right && Input.GetKey(KeyCode.E))
            StartCoroutine(ForceOverTtime(-value, 0.5f));
    }

    //private void FixedUpdate() {
    //    rb.velocity -= Vector3.Project(rb.velocity, transform.right);
    //}

    private IEnumerator ForceOverTtime(float force, float time) {

        Vector3 forward = Vector3.ProjectOnPlane(sofa.forward, Vector3.up).normalized;
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
