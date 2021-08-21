using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpPosition : MonoBehaviour {
    [SerializeField] private Transform fromPosition;
    [SerializeField] private Transform toPosition;
    [SerializeField] private float t;
    [SerializeField] private bool scaleWithDeltaTime = false;

    void Update() {
        if (scaleWithDeltaTime)
            transform.position = Vector3.Lerp(fromPosition.position, toPosition.position, t * Time.deltaTime);
        else
            transform.position = Vector3.Lerp(fromPosition.position, toPosition.position, t);
    }
}
