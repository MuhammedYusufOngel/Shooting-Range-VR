using UnityEngine;

public class GunLaserPointer : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float laserDistance = 50f; // Lazerin gideceği maksimum mesafe
    public LayerMask hitMask; // Lazerin çarpacağı katmanlar (Örn: Default, Enemy)

    void Start()
    {
        // Eğer atanmamışsa objenin üzerindeki LineRenderer'ı otomatik bul
        if (lineRenderer == null)
            lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        // Lazerin başlangıç noktasını namlunun ucu yap
        lineRenderer.SetPosition(0, transform.position);

        RaycastHit hit;
        // Namlunun ileri yönüne doğru görünmez bir ışın yolla
        if (Physics.Raycast(transform.position, transform.forward, out hit, laserDistance, hitMask))
        {
            // Eğer bir şeye çarparsa, lazerin ucunu çarptığı yere daya
            lineRenderer.SetPosition(1, hit.point);
        }
        else
        {
            // Hiçbir şeye çarpmazsa maksimum mesafeye kadar uzat
            lineRenderer.SetPosition(1, transform.position + transform.forward * laserDistance);
        }
    }
}