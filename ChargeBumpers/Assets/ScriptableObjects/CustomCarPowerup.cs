using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CarPowerup", menuName = "CarPowerup")]
public class CustomCarPowerup : ScriptableObject
{
    [Header("Powerup")]
    [SerializeField] private PowerupType type;
    public PowerupType Type => type;

    public enum PowerupType
    {
        NONE,
        Turbo,
        Rocket,
    }
}
