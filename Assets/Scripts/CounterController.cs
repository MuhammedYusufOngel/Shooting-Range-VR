using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class CounterController : MonoBehaviour
{
    public Transform head;
    public float spawnDistance = 2f;
    public GameObject countdownCanvas;
    public TMP_Text countdownText;

    private float elapsedTime = 3f;
    void Start()
    {
        
    }

    void Update()
    {
        if(PlayerController.instance.GetCountdown())
        {
            if (elapsedTime <= 0)
            {
                PlayerController.instance.StopCountdown();
                PlayerController.instance.StartTime();

                elapsedTime = 3f;
            }

            countdownText.text = Mathf.Ceil(elapsedTime).ToString();

            Debug.Log("Countdown: " + elapsedTime);

            countdownCanvas.SetActive(true);

            elapsedTime -= Time.deltaTime;

            countdownCanvas.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;

            countdownCanvas.transform.LookAt(new Vector3(head.position.x, countdownCanvas.transform.position.y, head.position.z));
        }
        else
        {
            countdownCanvas.SetActive(false);
        }

    }
}
