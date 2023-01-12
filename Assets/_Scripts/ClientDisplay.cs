using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClientDisplay : MonoBehaviour
{
    [SerializeField]
    private GameObject m_barreChaleur;
    [SerializeField]
    private GameObject m_clientImage;
    [SerializeField]
    private Text m_clientText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restaurant()
    {
        m_clientText.text = "Restaurant";
    }

    public void Client()
    {
        m_clientText.text = "Livrer";
    }
}
