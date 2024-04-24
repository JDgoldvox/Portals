using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    public Transform player;
    public Transform reciever;
    private bool playerOverlapping = false;

    // Update is called once per frame
    void Update()
    {
        if (playerOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position; 
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            //player has moved across the portal IF TRUE
            if (dotProduct < 0) {
                //teleport them

                float rotationDiff = Quaternion.Angle(transform.rotation, reciever.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = reciever.position + positionOffset;

                playerOverlapping = false;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOverlapping = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerOverlapping = false;
        }
    }
}
