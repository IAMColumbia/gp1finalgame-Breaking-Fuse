using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_WallTurret : MonoBehaviour
{
    public GameObject projectile;
    Player target;

    private float fireRate;
    private float fireRange;
    private float nextFire;

    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<Player>();
        fireRate = 2f;
        fireRange = 7f;
        nextFire = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        CheckIfTimeToFire(CheckIfCanFire());
    }

    bool CheckIfCanFire()
    {
        //if target is not above this enemy AND target is not too far below(within player's view), start shooting
        if (target.transform.position.y <= transform.position.y && (transform.position.y - target.transform.position.y) <= fireRange) return true;
        else
        {
            return false;
        }
    }

    void CheckIfTimeToFire(bool canFire)
    {
        if (Time.time > nextFire && canFire)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            nextFire = Time.time + fireRate;
        }
    }
}
