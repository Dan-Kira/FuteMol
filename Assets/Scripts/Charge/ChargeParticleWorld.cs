using System.Collections.Generic;
using UnityEngine;

public class ChargeParticleWorld : MonoBehaviour
{
    public static readonly List<ChargeParticleWorld> AllCharges = new List<ChargeParticleWorld>();

    [SerializeField] private float charge;

    public float Charge => charge;

    private void OnEnable()
    {
        AllCharges.Add(this);
    }

    private void OnDisable()
    {
        AllCharges.Remove(this);
    }
}