using UnityEngine;

public class BreakableTarget : MonoBehaviour
{
    public GameObject wholeMesh;
    public GameObject fragmentsRoot; // parent holding all fragment pieces
    public float explosionForce = 300f;
    public float explosionRadius = 3f;
    public float fragmentLifetime = 1f;

    public void Break(Vector3 hitPoint)
    {
        wholeMesh.SetActive(false);
        fragmentsRoot.SetActive(true);
        fragmentsRoot.transform.parent = null; // Detach fragments from the original target

        foreach (Rigidbody rb in fragmentsRoot.GetComponentsInChildren<Rigidbody>())
        {
            rb.AddExplosionForce(explosionForce, hitPoint, explosionRadius);
        }

        Destroy(fragmentsRoot, fragmentLifetime);
        Destroy(gameObject);
    }
}
