using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    public GameObject Player;
    public GameObject PlayerTeleport;
    void OnTriggerEnter()
    {
        Player.transform.position = PlayerTeleport.transform.position;
    }
}
