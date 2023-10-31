using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    [SerializeField] GameObject _levelPassPanel;


    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.gameObject.CompareTag("Player"))
        {
            _levelPassPanel.SetActive(true);

        }
    }


}
