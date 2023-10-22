using MoreMountains.TopDownEngine;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpecialAltar : MonoBehaviour
{
    [SerializeField] SpecialAltarType altarType;
    [SerializeField] int bloodCost;
    [SerializeField] TextMeshProUGUI costText;

    bool altarUsed;

    // Start is called before the first frame update
    void Start()
    {
        costText.text = bloodCost.ToString();
        altarUsed = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<BloodController>(out var bloodController))
        {
            if (bloodController.GetAmount() >= bloodCost && !altarUsed)
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

                altarUsed = true;

                costText.text = "";
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
