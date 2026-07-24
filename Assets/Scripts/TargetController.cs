using UnityEngine;

public class TargetController : MonoBehaviour
{    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "Bullet")
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
