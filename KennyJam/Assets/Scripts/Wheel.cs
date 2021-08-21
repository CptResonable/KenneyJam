using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wheel : MonoBehaviour {

    [SerializeField] private Transform sofa;
    [SerializeField] private Enums.Side side;

    private Rigidbody rb;

    private void Awake() {
        rb = GetComponent<Rigidbody>();

        if (side == Enums.Side.left)
            PlayerInput.rollEvent_L += PlayerInput_rollEvent;
        else
            PlayerInput.rollEvent_R += PlayerInput_rollEvent;
    }

    private void PlayerInput_rollEvent(float value) {
        //rb.AddTorque(transform.right * value * 10000);
        Debug.Log(value);

        StartCoroutine(ForceOverTtime(-value, 0.5f));
    }

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
