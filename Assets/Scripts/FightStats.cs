using System.Collections;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public class FightStat : MonoBehaviour
{
    public string unitName;
    public int damage;
    public int maxHP;
    public int currentHP;

    public GameObject DeathHUD;
    public GameObject FightMenuUI;
    public GameObject Monster;

    public Slider hpSlider;
    public bool invincible;
    public bool Phase2;

    public void Start()
    {
        DeathHUD.SetActive(false);
        FightMenuUI.SetActive(true);

        SetHUD();
    }

    public void Update()
    {

    }
    IEnumerator MainMenu()
    {
        Monster.GetComponent<Animator>().CrossFadeInFixedTime("Base Layer.Karkios_Death", 1f);
        yield return new WaitForSeconds(8);
        DeathHUD.SetActive(true);
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("TitleScreen");
    }
    public void SetHUD()
    {
        hpSlider.maxValue = maxHP;
        hpSlider.value = currentHP;

    }
    public void TakeDamage(int Damage)
    {
        if (!invincible)
        { currentHP -= damage; }

        if (currentHP < 0)
        {
            currentHP = 0;
        }
        hpSlider.value = currentHP;

        //Death Screen
        if (currentHP < 1)
        {
            FightMenuUI.SetActive(false);
            StartCoroutine(MainMenu());
            Debug.Log("Died");

        }
        if (GetComponent<Karkios_Behavior>() != null && currentHP < 50 && !invincible && !Phase2)
        {
            invincible = true;
            Monster.GetComponent<Animator>().CrossFadeInFixedTime("Base Layer.Karkios_Bury", 1f);
        }
    }
}
