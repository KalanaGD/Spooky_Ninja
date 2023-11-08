using UnityEngine;

public class UIManagerScript : MonoBehaviour
{
    public GameObject _levelPassPanel;
    

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Player"))
        {
            _levelPassPanel.SetActive(true);
        }
    }
}
