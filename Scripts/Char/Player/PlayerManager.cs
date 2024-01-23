using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private GameObject _player;

    public static PlayerManager playerManager;

    #region SimpleSingleton

    private void Awake()
    {
        if (playerManager != null)
            return;

        playerManager = this;
    }

    #endregion

    private void Update()
    {
        
    }

    public GameObject GetPlayer()
    {
        return _player;
    }
}
