using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Not elegant, but I was running out of time
public class HardcodedAddToInv : MonoBehaviour
{
    public void AddItem1()
    {
        InventoryTransfer.Instance.AddItem1();
    }
    
    public void AddItem2()
    {
        InventoryTransfer.Instance.AddItem2();
    }
    
    public void AddItem3()
    {
        InventoryTransfer.Instance.AddItem3();
    }
}
