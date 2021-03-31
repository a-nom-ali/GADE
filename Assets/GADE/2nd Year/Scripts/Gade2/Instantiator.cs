using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public Vector3 Velocity = new Vector3(0, 0.1f, 0);
    [SerializeField] private Transform m_Prefab;

    private int _count;
    // Start is called before the first frame update
    void Start()
    {
        m_Prefab.gameObject.SetActive(false);
    }

    void Update()
    {
        var p = transform.position;
        p += Velocity * Time.deltaTime;
        transform.position = p;

        //Debug.Log(Time.time);
    }
    // Update is called once per frame
    public void Instantiate()
    {
        m_Prefab.gameObject.SetActive(true);
        Instantiate(m_Prefab, transform);
        m_Prefab.gameObject.SetActive(false);
    }
}
