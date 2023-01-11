using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClientManager : MonoBehaviour
{
    private Client[] clients = new Client[4];

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(NewClientSpawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator NewClientSpawn()
    {
        foreach (var client in clients)
        {
            if (!client.IsRunning())
            {
                client.Activate();
                break;
            }
        }

        yield return new WaitForSeconds(Random.Range(20, 60)) ;

        StartCoroutine(NewClientSpawn());
    }
}
