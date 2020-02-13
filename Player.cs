using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player :MonoBehaviour
{
    public string isim;
    public Text populationText;
    int result;
    GameObject target;
    public GameObject[] enemies;
    public Button[] buttons;
    public Image DefendImage, AttackImage, PropagandaImage;
    public Sprite radar;
    public Sprite s400;
    public Sprite fighters;
    public Sprite nuclear;
    public Sprite propaganda;
    [Range(20000000, 100000000)]
    public int population = 50000000/10000;
    public bool played;
    private void Start()
    {
        buttons[1].enabled = false;
        buttons[2].enabled = false;
        buttons[0].enabled = false;
        populationText.text = population.ToString();
    }
   
    public void ChangeRadarImage()
    {
     
        DefendImage.sprite = radar;
        DisableDropDownList();
        played = true;
    }
    public void ChangeS400Image()
    {
        DefendImage.sprite = s400;
        DisableDropDownList();
        played = true;
    }
    public void PlayerSelected()
    {
        result = gameObject.GetComponentInChildren<Dropdown>().value;
        buttons[1].enabled = true;
        buttons[2].enabled = true;
        buttons[0].enabled = true;
        Debug.Log(result);
    }
    
    public void ChangeFighterImage()
    {
        AttackImage.sprite = fighters;
        DisableDropDownList();
        played = true;
    }
    public void ChangeNuclearImage()
    {
        for (int x = 0; x < enemies.Length; x++)
        {
            if (result == int.Parse(enemies[x].GetComponent<Player>().isim))
            {
                target = enemies[x];
                Debug.Log(target);
                
            }
        }
        NuclearResult(target);
        UpdatePopulation();
        AttackImage.sprite = nuclear;
        DisableDropDownList();
        played = true;
    }
    void UpdatePopulation()
    {
        target.GetComponent<Player>().populationText.text = target.GetComponent<Player>().population.ToString();
    }
    public void ChangePropagandaImage()
    {
        PropagandaImage.sprite = propaganda;
        DisableDropDownList();
        played = true;
    }
    public void DisableDropDownList()
    {
        gameObject.GetComponentInChildren<CanvasGroup>().alpha = 0;
    }
    #region RESULTS
    public void NuclearResult(GameObject newTarget)
    {
        //target=newTarget;
        float a = Random.Range(0f, 1f);
        if(a>=0.5f)
        {
            newTarget.GetComponent<Player>().population -= 3000000;
        }
        else if(a>=.2f && a<.5f)
        {
            Debug.Log("You missed");
        }
        else if (a<.2f)
        {
            Debug.Log("BackFired");
        }
        Debug.Log(newTarget.GetComponent<Player>().population);
    }
    #endregion RESULTS
}
