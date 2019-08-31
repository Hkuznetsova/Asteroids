using UnityEngine;
using System;

public class InputManager : MonoBehaviour
{
    public float Horizontal { get; private set; }
    public bool FireWeapons { get; private set; }

    public event Action OnFire = delegate { };

    [HideInInspector]
    public static InputManager Instance;

    private void Awake()
    {
        Instance = this;
    }

        private void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        FireWeapons = Input.GetButton("Fire1");
        if (FireWeapons)
            OnFire();
    }
}