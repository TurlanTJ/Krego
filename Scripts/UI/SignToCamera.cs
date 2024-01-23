using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignToCamera : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.forward = Camera.main.transform.forward;
    }
}
