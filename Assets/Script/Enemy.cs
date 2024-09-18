using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<DropSystem> itemDrops = new List<DropSystem>();
    
    public void DropLoot()
    {
        float chance = Random.Range(0f, 100f);
        for (int i = 0; i < itemDrops.Count; i++)
        {
            if(chance <= itemDrops[i].DropChance)
            {
                int amountToDrop = Random.Range(itemDrops[i].min, itemDrops[i].max);
                for (int j = 0; j < amountToDrop; j++)
                {
                   GameObject itemSpawn = Instantiate(itemDrops[i].ItemPrefab,transform.position, Quaternion.identity);
                   Destroy(itemSpawn, itemDrops[i].duration);
                   Rigidbody rb = itemSpawn.GetComponent<Rigidbody>();
                   rb.AddForce(transform.up * 5); 
                }
                Debug.Log($"{amountToDrop}{itemDrops[i].ItemName}(s) dropped");
            }
        }
    }

    private void OnDestroy()
    {
       DropLoot();
    }

    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
}
