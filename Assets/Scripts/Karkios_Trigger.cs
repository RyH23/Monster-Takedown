using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class Karkios_Trigger : MonoBehaviour
{
    //Calls the public bool Rotate and Move variables from Karkios_Behavior script
    public GameObject Karkios;

    //public Karkios_Behavior Rotate;
    //public Karkios_Behavior Move;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(GetRotatedIdiot());
    }
    
    //Start for the entire scene- cool intro :)
    private IEnumerator GetRotatedIdiot()
    {
        //Make Move and Rotation not possible
        Karkios.GetComponent<Karkios_Behavior>().Move = false;
        Karkios.GetComponent<Karkios_Behavior>().Rotate = false;

        //Start Flower Down Animation
        Karkios.GetComponent<Animator>().CrossFadeInFixedTime("Base Layer.Karkios_FlowerDown", .2f);

        yield return new WaitForSeconds(.33f);
        Debug.Log("First Wait");

        //Make Move and Rotate possible
        Karkios.GetComponent<Animator>().CrossFadeInFixedTime("Base Layer.Karkios_Emerge", .5f);

        yield return new WaitForSeconds(1.8f);
        Debug.Log("Second Wait");

        yield return new WaitForSeconds(6f);
        Debug.Log("Third Wait");

        //ROAR ^.=.^
        Karkios.GetComponent<Animator>().Play("Base Layer.Karkios_Roar");

        gameObject.SetActive(false);
    }
}
