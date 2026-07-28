using UnityEngine;
using TMPro;

public class EpisodeController : MonoBehaviour
{    
    public Transform head;
    public float spawnDistance = 2f;
    public GameObject episodeCanvas;
    public TMP_Text episodeText;

    private float elapsedTime = 0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(PlayerController.instance.GetIsNextLevel() == 1)
        {
            episodeCanvas.SetActive(true);
            elapsedTime += Time.deltaTime;
            episodeText.text = "Congratulations! You've completed Episode " + PlayerController.instance.GetLevel() + "! Get ready for Episode " + (PlayerController.instance.GetLevel() + 1) + "!";
            
            if(elapsedTime >= 2f)
            {
                PlayerController.instance.LevelDesign();
                PlayerController.instance.SetLevel(PlayerController.instance.GetLevel() + 1);
                PlayerController.instance.SetIsNextLevel(0);
                PlayerController.instance.StartCountdown();
                episodeCanvas.SetActive(false);
                elapsedTime = 0f;
            }
        }
        else if(PlayerController.instance.GetIsNextLevel() == -1)
        {
            episodeCanvas.SetActive(true);
            elapsedTime += Time.deltaTime;
            episodeText.text = "Unfortunately, you didn't complete Episode " + PlayerController.instance.GetLevel() + ". Start to be better!";

            if(elapsedTime >= 2f)
            {
                PlayerController.instance.LevelDesign();
                PlayerController.instance.SetLevel(1);
                PlayerController.instance.SetIsNextLevel(0);
                PlayerController.instance.StartCountdown();
                episodeCanvas.SetActive(false);
                elapsedTime = 0f;
            }
        }

        episodeCanvas.transform.position = head.position + new Vector3(head.forward.x, 0, head.forward.z).normalized * spawnDistance;

        episodeCanvas.transform.LookAt(new Vector3(head.position.x, episodeCanvas.transform.position.y, head.position.z));
    }
}
