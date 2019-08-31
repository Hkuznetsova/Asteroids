using UnityEngine;
using UnityEditor;

public class Bonus : MonoBehaviour
{
    [SerializeField] float restoreHealth;

    public float RestoreHealth { get { return restoreHealth; } }
}