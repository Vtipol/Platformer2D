using UnityEngine;

public class Coin : MonoBehaviour, ICollectable
{
    public int coinValue = 1;
    public void collect()
    {
        //Debug.Log("coin collected");
        ScoreSystem.Instance.Coins += coinValue;
        gameObject.SetActive(false);
    }
}
