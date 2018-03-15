using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorInteraction : MonoBehaviour {

    public enum eDoorState
    {
        Active,     // Open
        Inactive,   // Close
    }

    private eDoorState door_state;

    void Start()
    {
        door_state = eDoorState.Inactive;
    }

    public void TriggerInteraction()
    {
        if (!GetComponent<Animation>().isPlaying)
        {
            Debug.Log("Interactive object");
            switch (door_state)
            {
                case eDoorState.Active:
                    GetComponent<Animation>().Play("DoorClose");
                    door_state = eDoorState.Inactive;
                    break;
                case eDoorState.Inactive:
                    GetComponent<Animation>().Play("DoorOpen");
                    door_state = eDoorState.Active;
                    break;
                default:
                    break;
            }
        }
    }
}
