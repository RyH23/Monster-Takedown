using UnityEngine;

public class PlayerHit : MonoBehaviour
{
    public GameObject Player;
    public GameObject Karkios;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Karkios.GetComponent<FightStat>().TakeDamage(Player.GetComponent<FightStat>().damage);
        }
    }
}
