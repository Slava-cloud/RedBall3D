using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Respawn respawnObject; // Reference to the Respawn script



    void Start()
    {
        respawnObject = GameObject.Find("Respawn").GetComponent<Respawn>(); // Find the Respawn object in the scene
    }
    
    
    void OnTriggerEnter(Collider touch)
    {
        if (touch.CompareTag("Player"))
        {
            respawnObject.transform.position = transform.position; // Set the respawn position to the checkpoint position
            Destroy(gameObject); // Destroy the checkpoint object
        }
    }
}
