using System;
using System.Collections.Generic;

/// <summary>
/// A basic implementation of a Queue
/// </summary>
public class PersonQueue
{
    private readonly List<Person> _queue = new();

    public int Length => _queue.Count;

    /// <summary>
    /// Add a person to the queue (to the back)
    /// </summary>
    /// <param name="person">The person to add</param>
    public void Enqueue(Person person)
    {
        _queue.Add(person); // Add to the end
    }

    /// <summary>
    /// Remove the person at the front of the queue
    /// </summary>
    public Person Dequeue()
    {
        if (IsEmpty())
            throw new InvalidOperationException("The queue is empty.");

        var person = _queue[0];   // Get the first person
        _queue.RemoveAt(0);       // Remove from the front
        return person;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}
