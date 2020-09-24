using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _maxHealth;
    [SerializeField]
    private int _minHealth;

    public int currentHealth;

    public int damageAmount = 10;

    //[Header ("Armor.  This value will be subractedfrom damage.")]
    //public int armorMod;

    //[Header("Resistance.  The remaining damage will be divided by this value.")]
    //public int resistanceMod;

    //[Header("Vulnerablility.  This value will be multiplied by the remaining damage.")]
    //public int vulnerabilityMod;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = _maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth < _minHealth)
        {
            Destroy(this.gameObject);
        }
    }
}
