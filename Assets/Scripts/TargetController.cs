using UnityEngine;

public class TargetController : MonoBehaviour
{    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.tag == "Bullet")
        {
            PlayerController.instance.AddScore();
            Destroy(gameObject);
        }
    }

    void Update()
    {
        
    }
}
