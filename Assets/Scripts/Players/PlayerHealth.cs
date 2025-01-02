using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [Header("Player")]
    [SerializeField] private PlayerConfig PlayerConfig;
    public void RecoverHealth(float amount)
    {
        PlayerConfig.CurrentHealth += amount;
        if(PlayerConfig.CurrentHealth>PlayerConfig.MaxHealth)
        {
            PlayerConfig.CurrentHealth = PlayerConfig.MaxHealth;
        }
    }
    public void TakeDamage(float amount)
    {
        if(PlayerConfig.CurrentArmor>0)
        {
            PlayerConfig.CurrentArmor = Mathf.Max(PlayerConfig.CurrentArmor - amount, 0f);
        }
        else
        {
            PlayerConfig.CurrentHealth = Mathf.Max(PlayerConfig.CurrentHealth - amount, 0f);
        }
        if(PlayerConfig.CurrentHealth <= 0)
        {
            PlayerDead();
        }
    }
    public void PlayerDead()
    {
        Destroy(gameObject);
    }
}
