using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hand : MonoBehaviour {
    [SerializeField] private Enums.Side side;

    [SerializeField] private Transform forwardPos;
    [SerializeField] private Transform idlePos;
    [SerializeField] private Transform backPos;

    private void Awake() {
        PlayerInput.rollEvent += PlayerInput_rollEvent;
        PlayerInput.rollInitEvent += PlayerInput_rollInitEvent;
    }

    private void PlayerInput_rollInitEvent(float value) {
        throw new System.NotImplementedException();
    }

    private void PlayerInput_rollEvent(float value) {
        throw new System.NotImplementedException();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
