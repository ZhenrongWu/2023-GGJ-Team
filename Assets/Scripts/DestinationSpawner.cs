using UnityEngine;

public class DestinationSpawner : MonoBehaviour
{
    [SerializeField] private Transform  targetTrans1, targetTrans2;
    [SerializeField] private GameObject puddle,       mound;

    private void Awake()
    {
        int randomNumber = Random.Range(0, 2);
        if (randomNumber == 0)
        {
            Instantiate(puddle, targetTrans1);
            Instantiate(mound,  targetTrans2);
        }
        else
        {
            Instantiate(mound,  targetTrans1);
            Instantiate(puddle, targetTrans2);
        }
    }
}