using UnityEngine;

public class TargetController : MonoBehaviour
{
    BreakableTarget breakableTarget;
    void Start()
    {
        breakableTarget = GetComponentInParent<BreakableTarget>();
    }
    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "Bullet")
        {
            breakableTarget.Break(other.ClosestPointOnBounds(transform.position));
            PlayerController.instance.AddScore();
            Destroy(gameObject);
        }
    }
}
