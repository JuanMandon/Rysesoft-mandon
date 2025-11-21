using UnityEngine;

/// <summary>
/// Singleton: Handles transferring items (prefabs) between two UI parents
/// and allows adding specific items to the pile via UnityEvents.
/// </summary>
public class InventoryTransfer : MonoBehaviour
{
    //Couldve been more elegant if we used an event bus or action system, but for time sake, a singleton
    public static InventoryTransfer Instance { get; private set; }

    [Header("Parents")]
    [SerializeField] private Transform pileParent;
    [SerializeField] private Transform playerParent;

    [Header("Prefabs")]
    [SerializeField] private GameObject item1Prefab;
    [SerializeField] private GameObject item2Prefab;
    [SerializeField] private GameObject item3Prefab;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Moves all children from pile → player, or player → pile depending on current state.
    /// </summary>
    public void TransferAll()
    {
        bool pileHasItems = pileParent.childCount > 0;

        Transform from = pileHasItems ? pileParent : playerParent;
        Transform to   = pileHasItems ? playerParent : pileParent;

        for (int i = from.childCount - 1; i >= 0; i--)
        {
            Transform child = from.GetChild(i);
            child.SetParent(to);
        }
    }

    /// <summary>
    /// Adds a prefab instance to the pile parent.
    /// </summary>
    public void AddItemToPile(GameObject prefab)
    {
        if (prefab == null) return;

        GameObject go = Instantiate(prefab, pileParent);
        go.transform.localScale = Vector3.one; // ensures it fits nicely in UI
    }

    public void AddItem1() => AddItemToPile(item1Prefab);
    public void AddItem2() => AddItemToPile(item2Prefab);
    public void AddItem3() => AddItemToPile(item3Prefab);
}