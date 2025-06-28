using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    [SerializeField] Transform BulletSpawnPoint;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] float bulletSpeed = 10f;
    [SerializeField] int spawnRate = 5; //seconds
    [SerializeField] Animator cannonAnimator;
    private void Start()
    {
        StartCoroutine(FireBulletRoutine());
    }

    private IEnumerator FireBulletRoutine()
    {
        while (true)
        {
            FireBullet();
            yield return new WaitForSeconds(spawnRate);
        }
    }

    private void FireBullet()
    {
        var bullet = Instantiate(BulletPrefab, BulletSpawnPoint.position, BulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = BulletSpawnPoint.forward * bulletSpeed;

        // Play the aim animation
        if (cannonAnimator != null)
        {
            cannonAnimator.SetTrigger("CannonShot");
            Debug.Log("Firing Animation");
        }
        else
        {
            Debug.LogError("Animator component is not assigned.");
        }
    }
}
