using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class FireBulletOnActivate : MonoBehaviour
{
    public GameObject bullet;
    public ParticleSystem muzzleFlash;
    public Transform firePoint;
    public float bulletSpeed = 20f;
    public AudioSource gunShotSound;

    private XRGrabInteractable grabInteractable;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
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
        Destroy(newBullet, 5f);
        PlayerController.instance.AddBullet();
        gunShotSound.Play();
        if(muzzleFlash != null)
            muzzleFlash.Play();
    }
}
