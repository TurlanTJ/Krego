using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectDescription : MonoBehaviour
{
    [SerializeField] private GameObject _effectDescription;

    public void ShowEffectDescription()
    {
        _effectDescription.SetActive(true);
    }

    public void HideEffectDescription()
    {
        _effectDescription.SetActive(false);
    }
}
