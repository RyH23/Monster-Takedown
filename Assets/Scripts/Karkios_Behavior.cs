using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Karkios_Behavior : MonoBehaviour
{
    public GameObject Karkios;
    public GameObject Player;

    public GameObject SwipeAttackTrigger;
    public GameObject EmergeAttackTrigger;
    public GameObject HipCheckAttackTrigger;
    public GameObject TailBashTrigger;

    public Transform Target;
    //Attacks
    public Transform Front;
    public Transform Left;
    public Transform Right;
    public Transform Back;

    public FightStat Monster;

    //Layer to check for Player
    public LayerMask PlayerMask;

    public float Speed = .01f;

    public bool Rotate;
    public bool Move;

    public bool isAttacking;
    public bool Idle;

    public AudioSource KarkiosAudioSource;
    public AudioClip KarkiosRoar;
    public AudioClip KarkiosDeath;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Starts the game out with the Karkios in the ground.
        Rotate = false;
        Move = false;

        isAttacking = false;
        Idle = false;

        gameObject.SetActive(true);

        SwipeAttackTrigger.SetActive(false);
        EmergeAttackTrigger.SetActive(false);
        HipCheckAttackTrigger.SetActive(false);
        TailBashTrigger.SetActive(false);

        Karkios.GetComponent<Animator>().Play("Base Layer.Karkios_Flower");
        Karkios.transform.LookAt(Player.transform.position);

    }

    //Rotation Script :)
    void Update()
    {
        if (Rotate == true)
        {
            //Get rotation location from Player
            Quaternion lookRotation = Quaternion.LookRotation(Target.position - Player.transform.position);

            //Makes the monster gradually turn towards player
            transform.rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * Speed * 80f);

            //Movement Script
            if (Move == true)
            {
                Karkios.transform.position = Vector3.MoveTowards(Karkios.transform.position, Player.transform.position, Speed * 1f);
            }
        }
        StartCoroutine(KarkiosAttack());
        
    }

    public IEnumerator KarkiosAttack()
    {
        //Karkios Fight Mechanics

        //Randomizer for Attacks
        if (Monster.currentHP < 1)
        {
            yield break;
            //Death Animation
        }
        //This script randomizes numbers that the script will then call upon to see what attack will happen.
        float Attack = Random.Range(0f, 10f);

        //Attack in front of the Karkios
        if (Physics.CheckSphere(Front.position, 5, PlayerMask) && !isAttacking && Attack > 3)
        {
            Karkios.GetComponent<Animator>().CrossFadeInFixedTime("Base Layer.Karkios_Swipe", 1f);
        }
        else if (Physics.CheckSphere(Front.position, 5, PlayerMask) && !isAttacking && Attack < 2)
        {
            Karkios.GetComponent<Animator>().CrossFadeInFixedTime("Base Layer.Karkios_Bury", 1f);
            yield return new WaitForSeconds(6.7f);
            Karkios.GetComponent<Animator>().Play("Base Layer.Karkios_Emerge");
        }
        else if (Physics.CheckSphere(Front.position, 5, PlayerMask) && !isAttacking && Attack < 4)
        {
            Karkios.GetComponent<Animator>().CrossFadeInFixedTime("Base Layer.Karkios_Roar", 1f);
        }

        //Attack to the Left of the Karkios
        else if (Physics.CheckSphere(Left.position, 5, PlayerMask) && !isAttacking && Attack < 6)
        {
            Karkios.GetComponent<Animator>().CrossFadeInFixedTime("Base Layer.Karkios_Hipcheck", 1f);
        }
        else if (Physics.CheckSphere(Left.position, 5, PlayerMask) && !isAttacking && Attack > 5) 
        {
            Karkios.GetComponent<Animator>().CrossFadeInFixedTime("Base Layer.Karkios_Jump", 1f);
        }

        //Attack to the Right of the Karkios
        else if (Physics.CheckSphere(Right.position, 5, PlayerMask) && !isAttacking)
        {
            Karkios.GetComponent<Animator>().CrossFadeInFixedTime("Base Layer.Karkios_Jump", 1f);
        }

        //Attack to the back of the Karkios
        else if (Physics.CheckSphere(Back.position, 5, PlayerMask) && !isAttacking && Attack < 9)
        {
            Karkios.GetComponent<Animator>().CrossFadeInFixedTime("Base Layer.Karkios_TailBash", 1f);
        }
        else if (Physics.CheckSphere(Back.position, 5, PlayerMask) && !isAttacking)
        {
            Karkios.GetComponent<Animator>().CrossFadeInFixedTime("Base Layer.Karkios_Bury", 1f);
            yield return new WaitForSeconds(6.7f);
            Karkios.GetComponent<Animator>().Play("Base Layer.Karkios_Emerge");
        }
        else if (!isAttacking && Idle)
        {
            Karkios.GetComponent<Animator>().Play("Base Layer.Karkios_Walk");
        }
    }
    //Sounds
    public void Roar()
    {
        KarkiosAudioSource.clip = KarkiosRoar;
        KarkiosAudioSource.Play();
    }
    public void DeathRoar()
    {
        KarkiosAudioSource.clip = KarkiosDeath;
        KarkiosAudioSource.Play();
    }
}
