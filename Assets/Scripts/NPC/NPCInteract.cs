using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteract : MonoBehaviour
{
    public Vector3 boxSize = new Vector3(2f, 2f, 2f);
    public GameObject notification;
    private bool playerInRange = false;

    private void Start()
    {
        notification.SetActive(false);
    }

    void Update()
    {
        CheckPlayerInRange();

        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            //Here lagay yung pag open nung Dial Box
        }
    }

    private void CheckPlayerInRange()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, boxSize / 2);
        playerInRange = false;

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                notification.SetActive(true);
                playerInRange = true;
                break;
            }
            else
            {
                notification.SetActive(false);
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a red box in the scene view to visualize the interaction area
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position, boxSize);
    }
}
