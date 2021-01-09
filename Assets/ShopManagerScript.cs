using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShopManagerScript : MonoBehaviour
{

    public int[,] shopItems = new int[5,5];    // number of item in the shop
    public float coins;                         // currency
    public Text CoinsTXT;

    // Start is called before the first frame update
    void Start()
    {
        CoinsTXT.text = "Coins:" + coins.ToString();

        // ID
        shopItems[1,1] = 1;   
        shopItems[1,2] = 2;   
        shopItems[1,3] = 3;   
        shopItems[1,4] = 4;   

        // price

        shopItems[2,1] = 10;   
        shopItems[2,2] = 20;   
        shopItems[2,3] = 30;   
        shopItems[2,4] = 40;   

        // quantity

        shopItems[3,1] = 0;   
        shopItems[3,2] = 0;   
        shopItems[3,3] = 0;   
        shopItems[3,4] = 0;   


    }

    // Update is called once per frame
    public void Buy()
    {
        GameObject ButtionRef = GameObject.FindGameObjectWithTag("Event").GetComponent<EventSystem>().currentSelectedGameObject;

        // check if we have enough money
        if (coins >= shopItems[2 , ButtionRef.GetComponent<ButtonInfo>().ItemID]){
            // if we buy it
            coins -= shopItems[2 , ButtionRef.GetComponent<ButtonInfo>().ItemID];    // subtract coins

            shopItems[3 , ButtionRef.GetComponent<ButtonInfo>().ItemID]++;      // increment quantity

            CoinsTXT.text = "Coins:" + coins.ToString();
            ButtionRef.GetComponent<ButtonInfo>().QuantityTxt.text = shopItems[3 , ButtionRef.GetComponent<ButtonInfo>().ItemID].ToString();
        }
    
    }
}
