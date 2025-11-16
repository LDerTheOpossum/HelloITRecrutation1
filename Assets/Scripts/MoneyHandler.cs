using UnityEngine;
using TMPro;

public class MoneyHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyDisplay;
    [SerializeField] private int money;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneyDisplay = GetComponent<TextMeshProUGUI>();
        money = 100;
    }

    // Update is called once per frame
    void Update()
    {
        moneyDisplay.text = "Your balance: \n" + money + "PLN";
    }
    public void MoneyDecrease()
    {
        money -= 25;
    }
    public void MoneyIncrease(int gain)
    {
        money += gain;
    }
}
