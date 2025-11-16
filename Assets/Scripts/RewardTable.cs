using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Reward
{
    public GameObject rewardObject;
    public int rewardAmmount;
    public int rewardClass;
}

public class RewardTable : MonoBehaviour
{
    public Reward[] rewardPool;
}
