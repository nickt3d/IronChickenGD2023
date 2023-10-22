using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAltar : MonoBehaviour
{
    [SerializeField] SpecialAltarType altarType;
    [SerializeField] int bloodCost;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BloodController>(out var bloodController))
        {
            print("Blood: " + bloodController.GetAmount());

            if (bloodController.GetAmount() >= bloodCost)
            {
                bloodController.RemoveBlood(bloodCost);

                switch (altarType)
                {
                    case SpecialAltarType.Blood:

                        bloodController.IncreaseMaxBlood(10);

                        break;
                    case SpecialAltarType.Health:

                        GameObject.FindGameObjectWithTag("Player").GetComponent<Health>().MaximumHealth += 10;

                        break;
                    case SpecialAltarType.Speed:

                        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterMovement>().WalkSpeed += 1;
                        GameObject.FindGameObjectWithTag("Player").GetComponent<CharacterRun>().RunSpeed += 1;

                        break;
                }
            }
        }
        
    }
}

public enum SpecialAltarType
{
    Blood,
    Health,
    Speed
}
