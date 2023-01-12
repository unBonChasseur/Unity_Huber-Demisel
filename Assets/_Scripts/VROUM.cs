using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VROUM : MonoBehaviour
{
    [SerializeField]
    private GameObject clientManager;

    [SerializeField]
    private GameObject[] UI; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Restaurant"))
        {
            foreach(GameObject ittt in UI)
            {
                ittt.GetComponent<ClientDisplay>().Client();
            }
            for (int i = 0; i < clientManager.GetComponent<SpawnClient>().canBeDelivered.Count; i++)
            {
                if (collision.collider.gameObject.layer == LayerMask.NameToLayer(clientManager.GetComponent<SpawnClient>().deliveryType[i]))
                {
                    clientManager.GetComponent<SpawnClient>().canBeDelivered[i] = true;
                    
                }

            }
        }

    }
}
