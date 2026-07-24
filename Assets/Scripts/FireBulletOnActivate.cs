using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public ParticleSystem muzzleFlash;
    public Transform firePoint;
    public float bulletSpeed = 20f;

    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(FireBullet);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireBullet(ActivateEventArgs args)
    {
        GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        Rigidbody rb = newBullet.GetComponent<Rigidbody>();
        rb.linearVelocity = firePoint.forward * bulletSpeed;
        Destroy(newBullet, 5f); // Destroy the bullet after 5 seconds to prevent clutter
        PlayerController.instance.AddBullet();
        if(muzzleFlash != null)
            muzzleFlash.Play();
    }
}
