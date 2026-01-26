using Microsoft.VisualStudio.TestTools.UnitTesting;

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario:
    // Enqueue multiple items with different priorities and dequeue.
    // Expected Result:
    // The item with the highest priority is returned.
    // Defect(s) Found:
    // Original code did not always remove the highest-priority item correctly.
    public void TestPriorityQueue_HighestPriorityRemoved()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("High", result);
    }

    [TestMethod]
    // Scenario:
    // Enqueue multiple items with the same highest priority.
    // Expected Result:
    // The item closest to the front of the queue (FIFO) is removed first.
    // Defect(s) Found:
    // Original code removed the last item instead of the first when priorities matched.
    public void TestPriorityQueue_FIFOForSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First", 10);
        priorityQueue.Enqueue("Second", 10);
        priorityQueue.Enqueue("Third", 5);

        var result = priorityQueue.Dequeue();

        Assert.AreEqual("First", result);
    }

    [TestMethod]
    // Scenario:
    // Dequeue should remove the item from the queue.
    // Expected Result:
    // After dequeuing once, the next dequeue should return the next highest-priority item.
    // Defect(s) Found:
    // Original code returned a value but did not remove it from the queue.
    public void TestPriorityQueue_ItemIsRemoved()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("A", 1);
        priorityQueue.Enqueue("B", 5);

        var first = priorityQueue.Dequeue();
        var second = priorityQueue.Dequeue();

        Assert.AreEqual("B", first);
        Assert.AreEqual("A", second);
    }

    [TestMethod]
    // Scenario:
    // Dequeue from an empty queue.
    // Expected Result:
    // An InvalidOperationException is thrown with the message "The queue is empty."
    // Defect(s) Found:
    // None (exception behavior required by specification).
    [ExpectedException(typeof(InvalidOperationException))]
    public void TestPriorityQueue_EmptyQueueThrowsException()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Dequeue();
    }

    [TestMethod]
    // Scenario:
    // Verify exception message when dequeuing from an empty queue.
    // Expected Result:
    // Exception message should be exactly "The queue is empty."
    // Defect(s) Found:
    // Ensures strict compliance with requirements.
    public void TestPriorityQueue_EmptyQueueExceptionMessage()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Expected exception was not thrown.");
        }
        catch (InvalidOperationException ex)
        {
            Assert.AreEqual("The queue is empty.", ex.Message);
        }
    }
}
