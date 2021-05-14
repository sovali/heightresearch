using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{
    public float damage = 2f;
    public float radius = 1f;
    public LayerMask layerMask;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, layerMask);
        //print(hits.Length);
        if(hits.Length > 0)
        {
            print("We hit" + hits[0].gameObject.tag);

            hits[0].gameObject.GetComponent<XbotHealthScript>().ApplyDamage(damage); //This is only for enemies and axe
            gameObject.SetActive(false);
        }
    }
}
