using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableSign : MonoBehaviour
{
    [SerializeField] private Canvas _intractSign;

    public void ShowInteractSign(bool canBeInteracted)
    {
        _intractSign.gameObject.SetActive(canBeInteracted);
    }
}
