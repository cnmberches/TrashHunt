using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public bool isFiringArrow = false;
    public int damage = 30;

    public void Shoot()
    {
        isFiringArrow = true;
    }
}
