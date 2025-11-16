using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MoneyHandler : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI moneyDisplay;
    [SerializeField] TextMeshProUGUI fixersWarning;
    [SerializeField] private int money;
    private int roundsInDebt = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moneyDisplay = GetComponent<TextMeshProUGUI>();
        money = 100;
        fixersWarning.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        moneyDisplay.text = "Your balance: \n" + money + "PLN";
    }
    public void MoneyDecrease()
    {
        money -= 25;
        if (money < 0)
        {
            roundsInDebt++;
            if (roundsInDebt > 0 && roundsInDebt < 3)
                fixersWarning.text = "Fixers will come soon!";
            else if (roundsInDebt >= 3 && roundsInDebt < 5)
                fixersWarning.text = "GET RID OF YOUR DEBT";
            else if (roundsInDebt > 5)
            {
                SceneManager.LoadScene("GameOver");
            }
        }
        else
        {
            roundsInDebt = 0;
            fixersWarning.text = "";
        }
    }
    public void MoneyIncrease(int gain)
    {
        money += gain;
    }
}
