using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    [SerializeField] private Enums.Side side;

    [SerializeField] private Transform forwardPos;
    [SerializeField] private Transform idlePos;
    [SerializeField] private Transform backPos;
    [SerializeField] private Transform centerPos;
    [SerializeField] private float wheelRadius;

    public enum HandState { idle, initiating, pushing }
    public HandState state = HandState.idle;
    public bool readyToPush = true;

    private void Awake() {
        if (side == Enums.Side.left) {
            PlayerInput.rollEvent_L += PlayerInput_rollEvent;
            PlayerInput.rollInitEvent_L += PlayerInput_rollInitEvent;
        }
        else {
            PlayerInput.rollEvent_R += PlayerInput_rollEvent;
            PlayerInput.rollInitEvent_R += PlayerInput_rollInitEvent;
        }
    }

    private void PlayerInput_rollInitEvent(float value) {
        if (state != HandState.idle)
            return;

        if (value > 0)
            StartCoroutine(MoveHand(idlePos, backPos, 0.2f));
        else
            StartCoroutine(MoveHand(idlePos, forwardPos, 0.2f));

        state = HandState.initiating;
    }

    private void PlayerInput_rollEvent(float value) {
        if (state != HandState.initiating)
            return;

        if (value > 0)
            StartCoroutine(PushTire(backPos, forwardPos, 0.5f));
        else
            StartCoroutine(PushTire(forwardPos, backPos, 0.5f));

        state = HandState.pushing;
    }

    private IEnumerator PushTire(Transform start, Transform stop, float duration) {

        float time = 0;
        while (time < duration) {
            time += Time.deltaTime;
            float t = time / duration;
            transform.position = Vector3.Lerp(start.position, stop.position, t);

            Vector3 centerToHand = transform.position - centerPos.position;
            transform.position = centerPos.position + centerToHand.normalized * wheelRadius;

            yield return new WaitForEndOfFrame();
        }

        StartCoroutine(MoveHand(stop, idlePos, 0.3f));
        yield return null;
    }

    private IEnumerator MoveHand(Transform start, Transform stop, float duration) {

        float time = 0;
        while (time < duration) {
            time += Time.deltaTime;
            float t = time / duration;
            transform.position = Vector3.Lerp(start.position, stop.position, t);
            yield return new WaitForEndOfFrame();
        }

        if (stop == idlePos)
            state = HandState.idle;

        yield return null;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
