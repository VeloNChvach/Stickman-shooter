using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Client : MonoBehaviour
{
    private NetworkView networkView;
    // For interpolation
    private float lastSynchronizationTime = 0f;
    private float syncDelay = 0f;
    private float syncTime = 0f;
    private Vector3 syncStartPosition = Vector3.zero;
    private Vector3 syncEndPosition = Vector3.zero;

    private void Awake()
    {
        networkView = gameObject.AddComponent<NetworkView>(); // Add component NetworkView
        //gameObject.AddComponent<NetworkIdentity>(); ??
    }

    private void Update()
    {
        if (networkView.isMine)
        {

        }
        else
        {
            SyncedMovement();
        }
    }

    // Serialized data
    private void OnSerializeNetworkView(BitStream stream, NetworkMessageInfo info)
    {
        Vector3 syncPosition = Vector3.zero;
        if (stream.isWriting)
        {
            syncPosition = transform.position;
            stream.Serialize(ref syncPosition);
        }
        else
        {
            stream.Serialize(ref syncPosition);
            // Time between this moment and last interpolation
            syncTime = 0f;
            syncDelay = Time.time - lastSynchronizationTime;
            lastSynchronizationTime = Time.time;

            syncStartPosition = transform.position;
            syncEndPosition = syncPosition;
        }
    }

    private void SyncedMovement()
    {
        syncTime += Time.deltaTime;
        transform.position = Vector3.Lerp(syncStartPosition, syncEndPosition, syncTime / syncDelay);
    }
}