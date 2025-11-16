using UnityEngine;
using Unity.Mathematics;
using System.Collections.Generic;
using System.Collections;

using Random = Unity.Mathematics.Random;
using Unity.VisualScripting;
using UnityEngine.UI;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;

public class CharacterRoulette : MonoBehaviour
{
    [SerializeField] private bool spining = false;
    [SerializeField] private int playersBet;
    [SerializeField] private int currenRouletteNumber = 0;
    [SerializeField] private int[] rouletteNumbers = new int[]
    {
        0, 32, 15, 19, 4, 21, 2, 25, 17, 34,
        6, 27, 13, 36, 11, 30, 8, 23, 10, 5,
        24, 16, 33, 1, 20, 14, 31, 9, 22, 18,
        29, 7, 28, 12, 35, 3, 26
    };

    private Random rng;

    [SerializeField] private TMP_InputField betInput;

    [SerializeField] private RewardSystem rewardSystem;
    [SerializeField] private MoneyHandler moneyHandler;

    private void Awake()
    {
        uint seed = (uint)System.DateTime.Now.Millisecond;
        rng = new Random(seed);

    }
    // Start is called once before the first executio]n of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!spining)
        {
            betInput.enabled = true;
            if (betInput.text != "" && !betInput.text.Contains("-"))
                playersBet = int.Parse(betInput.text);
            if (playersBet > 36)
            {
                betInput.text = "36";
                playersBet = 36;
            }
            if (playersBet < 0)
            {
                betInput.text = "0";
                playersBet = 0;
            }
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
            {
                spining = true;
                moneyHandler.MoneyDecrease();
                StartCoroutine(Spin());
            }

        }
        else
        {
            betInput.enabled = false;
        }
    }
    IEnumerator Spin()
    {
        int newCurrentNumber = 0;
        for (int i = 0; i < rng.NextInt(50, 150); i++)
        {
            yield return new WaitForSeconds(0.005f*i);
            if (newCurrentNumber >= 37)
                newCurrentNumber = 0;
            currenRouletteNumber = rouletteNumbers[newCurrentNumber];
            transform.position = new Vector3(-1 * newCurrentNumber, -2, 0);
            newCurrentNumber++;
        }
        spining = false;
        RateTheBet(currenRouletteNumber);
    }
    void RateTheBet(int roulettesNumber)
    {
        int betValue = Mathf.Abs(roulettesNumber - playersBet);
        GiveReward(betValue);
        Debug.Log(betValue);
    }
    void GiveReward(int score)
    {
        Debug.Log(score);
        Reward chosenReward = rewardSystem.ChosenReward(score);
        Instantiate(chosenReward.rewardObject);
    }
}
