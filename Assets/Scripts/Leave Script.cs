using System.Collections;
using UnityEngine;

public class LeaveScript : MonoBehaviour
{
    public GameObject Monster;
    public GameObject DirtSpray;
    public GameObject ParticleExit;
    public GameObject Exit;

    public float Speed = .01f;

    private void Start()
    {
        Exit.SetActive(false);
        DirtSpray.SetActive(false);
    }
    private void Update()
    {
        if (Monster.GetComponent<FightStat>().currentHP < 50)
        {
            StartCoroutine(BegoneThot());
        }
        //Animate Karkios Leaving 
        //Animate Ground Spray
        //Set amount of Time for Player to Leave
    }

    public IEnumerator BegoneThot()
    {
        yield return new WaitForSeconds(8f);
        DirtSpray.SetActive(true);
        DirtSpray.transform.position = Vector3.MoveTowards(DirtSpray.transform.position, Exit.transform.position, Speed * 5f);
        Exit.SetActive(true);
    }
}
