using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CarBalance", menuName = "CarBalance")]
public class CustomCarBalance : ScriptableObject
{
    [Header("Car")]
    [SerializeField] private float speed = 0;
    [SerializeField] private int weight = 0;
    public float Speed => speed;
    public int Weight => weight;

}
