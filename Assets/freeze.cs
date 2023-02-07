using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeze : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.constraints = RigidbodyConstraints.FreezeAll;
       
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
