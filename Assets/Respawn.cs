using System.Collections;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public GameObject playerObject; 




    public void RespawnPlayer()
    {
        playerObject.GetComponent<Rigidbody>().isKinematic = true; // Disable physics
        playerObject.transform.position = transform.position; // Replace with your respawn coordinates
      
        StartCoroutine(UnfreezePlayer()); // Start the coroutine to unfreeze the player
    } 
    
    IEnumerator UnfreezePlayer()
    {
        yield return new WaitForSeconds(0.1f); 
        playerObject.GetComponent<Rigidbody>().isKinematic = false; // Enable physics
    }




    void Start()
    {
        RespawnPlayer();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            RespawnPlayer();
        }

    }

}
 