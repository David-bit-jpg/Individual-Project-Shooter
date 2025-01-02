using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEnergy : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private PlayerConfig PlayerConfig;
    // Update is called once per frame

    public void UseEnergy(float amount)
    {
        PlayerConfig.CurrentEnergy -= amount;
        if(PlayerConfig.CurrentEnergy < 0)
        {
            PlayerConfig.CurrentEnergy = 0;
        }
    }
    public void RecoverEnergy(float amount)
    {
        PlayerConfig.CurrentEnergy += amount;
        if(PlayerConfig.CurrentEnergy>PlayerConfig.MaxEnergy)
        {
            PlayerConfig.CurrentEnergy=PlayerConfig.MaxEnergy;
        }
    }
}
