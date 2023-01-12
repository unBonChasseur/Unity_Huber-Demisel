using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 

public class Heat : MonoBehaviour
{
    [SerializeField]
    private float timer = 150.0f;

    //Heat slider
    [SerializeField]
    private Slider heat;

    //Boolean to run coroutine only once
    private bool coroutine_running = false;

    void Start()
    {
        //We get the slider attached to the current gameobjecct
        heat = gameObject.GetComponent<Slider>();
        //We update the slider default values
        heat.maxValue = timer;
        heat.value = timer;
    }

    //Function to set the heat timer values
    public void setTimer(float p_timer)
    {
        heat.maxValue = timer;
        heat.value = timer;
    }

    //Function to get current value (useful to calculate score) 
    public float getHeatValue()
    {
        return heat.value;
    }

    //To launch the timer when we see fit
    public void startTimer()
    {
        if (!coroutine_running)
        {
            coroutine_running = !coroutine_running;
            StartCoroutine(decountTimer());
        }
    }
    IEnumerator decountTimer()
    {
        do
        {
            heat.value -= 0.1f;
            yield return new WaitForSeconds(0.1f);
        } while (heat.value > 0);

        yield return null;
        
    } 
}
