using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnClient : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> spawn_points = new List<GameObject>();
    private List<bool> isTaken = new List<bool>();

    [SerializeField]
    private GameObject[] UI;

    [SerializeField]
    private GameObject[] Heat;

    [SerializeField]
    private List<string> resto_types = new List<string>(); 

    public List<GameObject> currentClients = new List<GameObject>();
    public List<bool> canBeDelivered = new List<bool>();
    public List<string> deliveryType = new List<string>();

    [SerializeField]
    private GameObject prefab;

    [SerializeField]
    private int maxClients;

    [SerializeField]
    private float deliveryDistance = 6.0f;

    [SerializeField]
    private GameObject car;

    [SerializeField]
    private GameObject scoreManager; 


    private void Start()
    {
        foreach(GameObject go in spawn_points)
        {
            isTaken.Add(false);
        }
        for (int i = 0; i < maxClients; i++)
        {
            UI[i].SetActive(false);
        }
    }

    private void Update()
    {
        spawn();
        despawn();
    }

    private void spawn()
    {
        for(int i = 0; i < maxClients; i++)
        {
            if (!UI[i].activeSelf && currentClients.Count < maxClients)
            {

                // Choisi l'endroit du spawn
                int spawn = Random.Range(0, spawn_points.Count - 1);
                while (isTaken[spawn])
                {
                    spawn = Random.Range(0, spawn_points.Count - 1);
                }
                isTaken[spawn] = true;
                GameObject spawnPoint = spawn_points[spawn];

                //Faire spawn un client
                GameObject newClient = Instantiate(prefab, spawnPoint.transform.position, Quaternion.identity);
                currentClients.Add(newClient);
                canBeDelivered.Add(false);
                deliveryType.Add(resto_types[Random.Range(0, resto_types.Count - 1)]);

                // Active l'UI
                UI[i].SetActive(true);
                //Heat[i].GetComponent<Heat>().setTimer(150.0f);
                UI[i].GetComponent<ClientDisplay>().Restaurant();

                Heat[i].GetComponent<Heat>().startTimer();
            }
        }
    }

    private void despawn()
    {
        int i = 0; 
        foreach(GameObject client in currentClients)
        {
            i++; 

            float currentDistance = Vector3.Distance(client.transform.position, car.transform.position);
            if (currentDistance <= deliveryDistance && canBeDelivered[i])
            {
                isTaken[i] = false;
                UI[i].GetComponent<ClientDisplay>().Restaurant();

                UI[i].SetActive(false);

                scoreManager.GetComponent<Score>().addScore(Mathf.Min(UI[i].GetComponent<Heat>().getHeatValue() / 150.0f * 5 + Random.Range(0, 2.5f), 5));

                //GameObject currClient = client;

                

                currentClients.RemoveAt(i);
                canBeDelivered.RemoveAt(i);

                deliveryType.RemoveAt(i);
                Destroy(currentClients[i]);
                currentClients[i] = null;
            }
        }
    }

    public void setMaxClients(int new_maxClients)
    {
        maxClients = new_maxClients; 
    }

    /* */


}
