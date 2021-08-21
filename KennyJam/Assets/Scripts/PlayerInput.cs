using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour {
    [SerializeField] float rollInterval = 0.2f;
    private bool isRolling = false;

    private float rollForce = 0;

    public delegate void FloatDelegate(float value);
    public static event FloatDelegate rollEvent_L;
    public static event FloatDelegate rollInitEvent_L;
    public static event FloatDelegate rollEvent_R;
    public static event FloatDelegate rollInitEvent_R;

    private void Update() {

        if (!Input.GetKey(KeyCode.Q) && !Input.GetKey(KeyCode.E))
            return;

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

        if (Input.GetKey(KeyCode.Q))
            rollInitEvent_L?.Invoke(rollForce);
        if (Input.GetKey(KeyCode.E))
            rollInitEvent_R?.Invoke(rollForce);

        yield return new WaitForSeconds(rollInterval);
        isRolling = false;

        if (Input.GetKey(KeyCode.Q))
            rollEvent_L?.Invoke(rollForce);
        if (Input.GetKey(KeyCode.E))
            rollEvent_R?.Invoke(rollForce);


        rollForce = 0;
        yield return null;
    }
}
