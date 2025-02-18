using TMPro;
using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    public TMP_Text CoinsTMP;

    [SerializeField]
    private int coins = 0;

    public int Coins { get => coins; set { coins = value; OnCoinsChanged(); } }

    public static ScoreSystem Instance;
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            //DontDestroyOnLoad(gameObject);
        }
        //else
        //{
        //    Destroy(gameObject);
        //}
    }

    public void OnCoinsChanged()
    {
        //Debug.Log("coin updated");
        CoinsTMP.text = Coins.ToString();
    }
}
