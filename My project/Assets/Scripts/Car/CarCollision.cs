using UnityEngine;

public class CollisionSoundPlayer : MonoBehaviour
{

    public GameObject blackoutPanel;

    public AudioSource audioSource;
    public AudioClip collisionSoundClip;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (blackoutPanel != null)
        {
            blackoutPanel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with another obstacle (you can use tags or layers for more specific checks)
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            // Play the collision sound
            if (audioSource != null && collisionSoundClip != null)
            {
                audioSource.PlayOneShot(collisionSoundClip);
            }

            if (blackoutPanel != null)
            {
                blackoutPanel.SetActive(true);
            }

            Invoke("ReloadScene", 5f);
        }
    }

    void ReloadScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
