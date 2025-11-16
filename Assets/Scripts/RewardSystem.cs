using System.Linq;
using UnityEngine;
using Random = Unity.Mathematics.Random;

public class RewardSystem : MonoBehaviour
{
    [SerializeField] private RewardTable rewards;
    private int playersBetScore = 0;
    private Random rng;
    private void Awake()
    {
        uint seed = (uint)System.DateTime.Now.Millisecond;
        rng = new Random(seed);

    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public Reward ChosenReward(int score)
    {
        Reward[] possibleRewardsPool = rewards.rewardPool
            .Where(r => r.rewardClass >= score).ToArray();
        if (possibleRewardsPool.Length == 0)
        {
            Debug.LogError("The 'possibleRewardsPool' array is empty");
            return rewards.rewardPool[0];
        }
        int index = rng.NextInt(0, possibleRewardsPool.Length - 1);
        Debug.Log(possibleRewardsPool.Length);
        return possibleRewardsPool[index];
    } 
}
