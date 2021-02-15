using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public GameObject healthBar;
    public GameObject player;

    private float currentLife;
    public float CurrentLife
    {
        get
        {
            return currentLife;
        }
        set
        {
            currentLife = value;
            healthBar.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, currentLife);

            if (currentLife <= 0)
            {
                Destroy(player.gameObject);
                Debug.Log("Call Game Over subroutines");
            }
        }
    }

    void Start()
    {
        CurrentLife = 100f;
    }

    public void ReduceLifeByTag(string tag)
    {
        switch (tag)
        {
            case "Enemy":
                CurrentLife -= 25f;
                break;
            default:
                break;

        }
    }

}