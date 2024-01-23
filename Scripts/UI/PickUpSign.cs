using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSign : MonoBehaviour
{

    [SerializeField] private GameObject _pickBtn;


    private void Awake()
    {
        HidePickUpSign();
    }

    public void ShowPickUpSign()
    {

        _pickBtn.SetActive(true);
    }

    public void HidePickUpSign()
    {
        _pickBtn.SetActive(false);
    }
}
