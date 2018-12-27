using System.Collections.Generic;
class LRU
{
    private int capacity;
    private Dictionary<int, LinkedListNode<Data>> list = 
              new Dictionary<int, LinkedListNode<Data>>();  
    private LinkedList<Data> lru = new LinkedList<Data>();
    public LRU(int capacity)
    {
        this.capacity = capacity;
    }
    
    public int Get(int key)
    {
        if(!list.ContainsKey(key))
        {
          return -1;
        }
        lru.Remove(list[key]);
        lru.AddLast(list[key]);
        return list[key].Value.value;
    }
    
    public void Put(int key, int value)
    {
        if(list.ContainsKey(key))
        {
          lru.Remove(list[key]);
          list[key].Value.value = value;
          lru.AddLast(list[key]);
        }
        else
        {
          list.Add(key, new LinkedListNode<Data>(new Data(key, value)));
          lru.AddLast(list[key]);
          removeLU();
        }
    }

    private void removeLU()
    {
      if(lru.Count > capacity)
      {
        list.Remove(lru.First.Value.key);
        lru.RemoveFirst();
      }
    }

    private class Data
    {
      public int key, value;

      public Data(int key, int value)
      {
        this.key = key;
        this.value = value;
      }
    }
}