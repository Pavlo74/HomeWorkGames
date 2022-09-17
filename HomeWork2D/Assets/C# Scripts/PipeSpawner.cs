using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public GameObject Pipes;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawner());
    }

    IEnumerator Spawner()
    {
        while(true)//нескінченний цикл
        {
            yield return new WaitForSeconds(2);
            float rand = Random.Range(-1f, 2.5f);//спавнення труб
            GameObject newPipes = Instantiate(Pipes, new Vector3(2, rand, 0), Quaternion.identity);//спавнення труб
            Destroy(newPipes, 10);//видалення труб
        }
    }
}
