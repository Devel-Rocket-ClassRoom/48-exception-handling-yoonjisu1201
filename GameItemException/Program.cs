using System;
using System.Collections.Generic;

// README.md를 읽고 코드를 작성하세요.
Inventory inventory = new Inventory(3);
Console.WriteLine("=== 인벤토리 테스트 ===");
try
{
    inventory.AddItem("검");
    inventory.AddItem("방패");
    inventory.AddItem("포션");
    inventory.AddItem("활");
}
catch(InventoryFullException ex)
{
    Console.WriteLine($"[인벤토리 오류] {ex.Message}");
}

Console.WriteLine();
inventory.ShowItems();
try
{
    inventory.RemoveItem("포션");
    inventory.RemoveItem("도끼");
}
catch(ItemNotFoundException ex)
{
    Console.WriteLine($"[인벤토리 오류] {ex.Message}");
}

Console.WriteLine();
inventory.ShowItems();





class Inventory
{
    private int maxCapacity;
    public List<string> items {  get; private set; }

    public Inventory(int maxCapacity)
    {
        this.maxCapacity = maxCapacity;
        items = new List<string>();
    }

    public void AddItem(string itemName)
    {
        if (items.Count >= maxCapacity)
        {
            throw new InventoryFullException(maxCapacity, itemName);
        }
        items.Add(itemName);
        Console.WriteLine($"아이템 '{itemName}' 추가됨");
    }

    public void RemoveItem(string itemName)
    {
        bool hasItem = false;
        if (items.Count <= 0)
        {
            throw new InventoryFullException(itemName);
        }

        for (int i = 0; i < items.Count; i++)
        {
            if (items[i] == itemName)
            {
                items.Remove(itemName);
                Console.WriteLine($"아이템 '{itemName}' 제거됨");
                hasItem = true;
            }
        }
        if (!hasItem)
        {
            throw new ItemNotFoundException(itemName);
        }

    }
    public void ShowItems()
    {
        Console.WriteLine($"현재 인벤토리: {string.Join(", ", items)}");
    }
}
class InventoryFullException : Exception  // 클래스 안에 생성자 만들기 보통 3개정도 만듬
{
    public int Capacity { get; set; }
    public string ItemName { get; set; }

    public InventoryFullException() { }

    public InventoryFullException(string message) : base(message) { }

    public InventoryFullException(int capacity, string itemname) 
        : base($"인벤토리가 가득 찼습니다. (용량: {capacity}, 아이템: {itemname})")
    {
        Capacity = capacity;
        ItemName = itemname;
    }
}

class ItemNotFoundException : Exception
{
    public string ItemName { get; set; }

    public ItemNotFoundException() { }
    public ItemNotFoundException(string message, Exception inner) : base(message, inner) { }
    public ItemNotFoundException(string itemname) 
        : base($"아이템을 찾을 수 없습니다: {itemname}") 
    {
        ItemName = itemname;
    }
}