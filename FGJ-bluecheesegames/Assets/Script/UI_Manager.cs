using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : MonoBehaviour
{
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI constitutionText;
    public TextMeshProUGUI agilityText;
    public TextMeshProUGUI hpText;
    public TextMeshProUGUI acText;

    public PlayerStats playerStats;

    // Start is called before the first frame update
    void Awake()
    {
        strengthText.text = strengthText.text + playerStats.strength.GetValue().ToString();
        constitutionText.text = constitutionText.text + playerStats.constitution.GetValue().ToString();
        agilityText.text = agilityText.text + playerStats.agility.GetValue().ToString();
        hpText.text = hpText.text + playerStats.maxHealth.ToString();
        acText.text = acText.text + playerStats.armor.GetValue().ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
