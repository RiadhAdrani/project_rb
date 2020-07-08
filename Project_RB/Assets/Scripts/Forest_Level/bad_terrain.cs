using UnityEngine;

public class bad_terrain : MonoBehaviour
{
    public GameObject rock; 
    public GameObject[] rocks_position;

    void Start()
    {
        for (int i=0 ; i <rocks_position.Length;i++){
            GameObject the_rock = Instantiate(rock,rocks_position[i].transform.position,Quaternion.Euler(Random.Range(0,180),Random.Range(0,180),Random.Range(0,180)));
            the_rock.transform.parent = gameObject.transform;
            
        }
    }

}
