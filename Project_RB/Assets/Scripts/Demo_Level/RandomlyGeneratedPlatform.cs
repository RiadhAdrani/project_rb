using UnityEngine;

public class RandomlyGeneratedPlatform : MonoBehaviour
{
    [SerializeField]private GameObject[] coins1 = null;
    [SerializeField]private GameObject[] coins2 = null;
    [SerializeField]private GameObject[] coins3 = null;

    
    private int i = 0;
    [SerializeField]private int index;
    
    void Start()
    {
        CoinsSpawner(coins1);
        CoinsSpawner(coins2);
        CoinsSpawner(coins3);
    }

    void CoinsSpawner(GameObject[] coins){
        index = Random.Range(0,3);
        for (i=0;i<coins.Length;i++){
            if (i == index) coins[i].SetActive(true);
            else coins[i].SetActive(false);
        }
    }


        
}
