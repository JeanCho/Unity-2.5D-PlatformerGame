using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour
{
    [SerializeField]
    private Text _coin_Text, _lives_Text;

    public void UpdateCoinDisplay(int coins)
    {
        _coin_Text.text = "Coins: " + coins;
    }
    public void UpdateLivesDisplay(int lives)
    {
        _lives_Text.text = "Lives: " + lives;
    }


}
