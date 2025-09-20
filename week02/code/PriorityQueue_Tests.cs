using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue one item and then dequeue it.
    // Expected Result: The same item is returned.
    // Defect(s) Found: None
    public void TestPriorityQueue_SingleEnqueueDequeue()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("A", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities.
    // Expected Result: Dequeue should always return the item with the highest priority.
    // Defect(s) Found: 
    public void TestPriorityQueue_HighestPriorityRemovedFirst()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        var result = priorityQueue.Dequeue();
        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority.
    // Expected Result: The first enqueued item with the highest priority should be removed first (FIFO).
    // Defect(s) Found: 
    public void TestPriorityQueue_SamePriorityFIFO()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 10);
        priorityQueue.Enqueue("Third", 10);

        var result1 = priorityQueue.Dequeue();
        var result2 = priorityQueue.Dequeue();

        Assert.AreEqual("First", result1);
        Assert.AreEqual("Second", result2);
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_EmptyQueueThrowsException()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected InvalidOperationException was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue items with mixed priorities, remove all, and check order.
    // Expected Result: Items should be dequeued in descending priority order, 
    // and FIFO when priorities are equal.
    // Defect(s) Found: 
    public void TestPriorityQueue_MixedPriorities()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low1", 1);
        priorityQueue.Enqueue("High1", 10);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High2", 10);

        var result1 = priorityQueue.Dequeue(); // High1 (first with priority 10)
        var result2 = priorityQueue.Dequeue(); // High2 (second with priority 10)
        var result3 = priorityQueue.Dequeue(); // Medium (priority 5)
        var result4 = priorityQueue.Dequeue(); // Low1 (priority 1)

        Assert.AreEqual("High1", result1);
        Assert.AreEqual("High2", result2);
        Assert.AreEqual("Medium", result3);
        Assert.AreEqual("Low1", result4);
    }
}
