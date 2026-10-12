

public class Inventory<T> where T : IInventoryItem
{
    List<T> items = new List<T>();

    public void Clear()
    {
        items.Clear();
    }
    public void Add(T item)
    {
        items.Add(item);
    }

    public void Remove(T item)
    {
        items.Remove(item);
    }

    public List<T> GetAll()
    {
        return items;
    }
    
    public int Count()
    {
        return items.Count;
    }

    public bool Contains(T item)
    {
        return items.Contains(item);
    }
    
    public T? FindById(int id)
    {
        return items.FirstOrDefault(x => x.Id == id);
    }
    
    public T? FindByName(string name)
    {
        return items.FirstOrDefault(x => x.Name == name);
    }
    
    public T? FindItem(T input)
    {
            return items.FirstOrDefault(x => x.Name == input.Name || x.Id == input.Id);
    }
    
    public void Sort<TKey>(Func<T, TKey> selector)
    {
        items = items.OrderBy(selector).ToList();
    }

    public void SortDescending<TKey>(Func<T, TKey> selector)
    {
        items = items.OrderByDescending(selector).ToList();
    }
}