using System.Collections.Generic;
using System.Linq;
using Restaurant.Models;

namespace Restaurant.Domain;

public class OrderQueue
{
    private List<Order> _queue = new();
    private object listLock = new();

    public void AddToQueue(Order order)
    {
        lock (listLock)
        {
            _queue.Add(order);
        }
    }

    public void RemoveFromQueue(Order order)
    {
        lock (listLock)
        {
            _queue.Remove(order);
        }
    }

    public int Count
    {
        get
        {
            lock (listLock)
            {
                return _queue.Count;
            }
        }
    }

    public IReadOnlyCollection<Order> Snapshot()
    {
        lock (listLock)
        {
            return _queue.ToList();
        }
    }
}