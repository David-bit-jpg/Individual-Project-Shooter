using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class PlayerConfig : ScriptableObject
{
    [Header("Data")]
    public int Level;
    public string Name;
    public Sprite Icon;

    [Header("Values")]
    public float CurrentHealth;
    public float CurrentArmor;
    public float CurrentEnergy;
    public float MaxHealth;
    public float MaxArmor;
    public float MaxEnergy;
    public float CriticalChance;
    public float CriticalDamage;
}
