public class Inventory<T> where T : IInventoryItem
{
    List<T> items = new List<T>();

    // remove every element of list
    public void Clear()
    {
        items.Clear();
    }

    // adds new element to list
    public void Add(T item)
    {
        items.Add(item);
    }

    // removes element from list
    public void Remove(T item)
    {
        items.Remove(item);
    }

    // returns copy of selected list
    public List<T> GetAll()
    {
        return items.ToList();
    }
    
    // gives the number of items in list
    public int Count()
    {
        return items.Count;
    }

    // returns wether the list contains a specific item
    public bool Contains(T item)
    {
        return items.Contains(item);
    }
    
    // finds item based on the id
    public T? FindById(int id)
    {
        return items.FirstOrDefault(x => x.Id == id);
    }
    
    // finds item based on the name
    public T? FindByName(string name)
    {
        return items.FirstOrDefault(x => x.Name == name);
    }
    
    // finds the item based on any input
    public T? FindItem(T input)
    {
            return items.FirstOrDefault(x => x.Name == input.Name || x.Id == input.Id);
    }
    
    // sorts the list in ascending order
    public void Sort<TKey>(Func<T, TKey> selector)
    {
        items = items.OrderBy(selector).ToList();
    }

    // sorts the list in descending order
    public void SortDescending<TKey>(Func<T, TKey> selector)
    {
        items = items.OrderByDescending(selector).ToList();
    }
}