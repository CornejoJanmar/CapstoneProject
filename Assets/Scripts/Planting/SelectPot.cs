using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class SelectPot : MonoBehaviour
{
    void Update()
    {
        if (PopupTrigger.isPlayerInTriggerZone && Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Create a layer mask that includes only the "Pot" layer
            int layerMask = LayerMask.GetMask("Pot");

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Debug.Log("Hit: " + hit.collider.name);
                ListOfSoil hitSoil = hit.collider.GetComponent<ListOfSoil>();

                if (hitSoil != null)
                {
                    ListOfSoil.DeselectAll(); // Deselect all pots first
                    hitSoil.Select(true); // Select the clicked pot

                    Debug.Log("Open Item");
                }
            }
            else
            {
                ListOfSoil.DeselectAll();
                Debug.Log("No Hit");
            }
        }

    }
}
