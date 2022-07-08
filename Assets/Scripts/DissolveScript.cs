using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveScript : MonoBehaviour
{

    public Material dissolveMaterial;
    public float health;
    public float maxHealth;
    public float DissolveSpeed;
    
    void Start()
    {
        dissolveMaterial.SetFloat("Vector1_c71373402cab4fbca238f6f0c9e8049e", health/maxHealth);
    }

 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && health > 60)
        {
            StartCoroutine(Dissolve());
        }
        if (Input.GetKeyDown(KeyCode.G) && health < -90)
        {
            StartCoroutine(Regeneration());
        }
    }

    IEnumerator Dissolve()
    {
        while (health > -100)
        {
            health -= DissolveSpeed * Time.deltaTime;
            dissolveMaterial.SetFloat("Vector1_c71373402cab4fbca238f6f0c9e8049e", health / maxHealth);
            yield return new WaitForSeconds(0.05f);
        }
    }
    
    IEnumerator Regeneration()
    {
        while (health < 65)
        {
            health += DissolveSpeed * Time.deltaTime;
            dissolveMaterial.SetFloat("Vector1_c71373402cab4fbca238f6f0c9e8049e", health / maxHealth);
            yield return new WaitForSeconds(0.05f);
        }
    }
}
