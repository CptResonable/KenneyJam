using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    [SerializeField] float rollInterval = 0.2f;
    private bool isRolling = false;

    private float rollForce = 0;

    public delegate void FloatDelegate(float value);
    public static event FloatDelegate rollEvent;

    private void Update() {

        float mouseDelta = Input.mouseScrollDelta.y;
        if (mouseDelta != 0) {
            if (isRolling)
                rollForce += mouseDelta * Time.deltaTime;
            else {
                rollForce += mouseDelta * Time.deltaTime;
                StartCoroutine(RollInterval());
            }
        }
    }

    private IEnumerator RollInterval() {
        isRolling = true;
        yield return new WaitForSeconds(rollInterval);
        isRolling = false;
        rollEvent.Invoke(rollForce);
        rollForce = 0;
        yield return null;
    }
}
