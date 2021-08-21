using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelModel : MonoBehaviour {
    [SerializeField] Enums.Side side;
    [SerializeField] Sofa sofa;
    [SerializeField] float radius;

    void FixedUpdate() {    
        float angvel = sofa.transform.InverseTransformVector(sofa.rb.GetPointVelocity(transform.position)).z / radius;
        if (side == Enums.Side.right)
            angvel *= -1;

        transform.RotateAround(transform.right, angvel * Time.deltaTime);
    }
}
