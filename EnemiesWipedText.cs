using UnityEngine;
using UnityEngine.UI;
using System.Collections;

// put this on the UI text that will display number of enemies destroyed so far
public class EnemiesWipedText : MonoBehaviour
{
    private Text numEnemies;

    void Start ()
    {
            numEnemies = GetComponent<Text>();
    }

    void Update ()
    {
            numEnemies.text = GameManager.Instance.enemiesWiped.ToString();
    }
}