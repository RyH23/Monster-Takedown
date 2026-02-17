using UnityEngine;

public class KarkiosHit: MonoBehaviour
{
    public GameObject Player;
    public GameObject Karkios;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Hurtbox Damage Script
    void OnTriggerEnter(Collider other)
    {
            Player.GetComponent<FightStat>().TakeDamage(Karkios.GetComponent<FightStat>().damage);
            Debug.Log("PlayerHurt"); 
    }
}
