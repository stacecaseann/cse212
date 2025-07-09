using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.
// If your tests were not sufficient, you might not find all the errors in the code. You should summarize the results of the tests and the errors found within the test case documentation above each test case.
[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Add items to the queue starting with the highest priority first should return those items first
    // Expected Result: "Item 1", "Item 2", "Item 3"
    // Defect(s) Found: 1) This returned the same value every time. The index in the loop needed to start at 0 and it needed to go up to _queue.Count instead of count - 1.
    //                  2) The item was never removed from the array
    //                  3) The comparison of the priority was incorrect (Assuming 1 is top priority)
    public void TestPriorityQueue_AddItemsWithDifferentPrioritiesLowestFirst()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Item 1", 1);
        priorityQueue.Enqueue("Item 2", 2);
        priorityQueue.Enqueue("Item 3", 3);

        string[] expectedResult = ["Item 1", "Item 2", "Item 3"];

        List<string> actualResult = [];

        for (int i = 0; i < 3; i++)
        {
            actualResult.Add(priorityQueue.Dequeue());
        }
        Assert.AreEqual(expectedResult.Length, actualResult.Count);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            Assert.AreEqual(expectedResult[i], actualResult[i]);
        }
    }

    [TestMethod]
    // Scenario: Add items to the queue starting with the lowest priority first should return the highest priority items first
    // Expected Result: "Item 1", "Item 2", "Item 3"
    // Defect(s) Found: None after the first test case issues were resolved
    public void TestPriorityQueue_AddItemsWithDifferentPrioritiesHighestFirst()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item 3", 3);
        priorityQueue.Enqueue("Item 2", 2);
        priorityQueue.Enqueue("Item 1", 1);

        string[] expectedResult = ["Item 1", "Item 2", "Item 3"];

        List<string> actualResult = [];

        for (int i = 0; i < 3; i++)
        {
            actualResult.Add(priorityQueue.Dequeue());
        }
        Assert.AreEqual(expectedResult.Length, actualResult.Count);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            Assert.AreEqual(expectedResult[i], actualResult[i]);
        }
    }

    [TestMethod]
    // Scenario: Add items to the queue where there are 2 with the same priority. 
    // Expected Result: "Item 1", "Item 2", "Item 3", "Item 4"
    // Defect(s) Found: The item comparison needed a < instead of <= to find the first value with the same priority
    public void TestPriorityQueue_AddItemsWithSamePriorities()
    {
        var priorityQueue = new PriorityQueue();

        priorityQueue.Enqueue("Item 1", 1);
        priorityQueue.Enqueue("Item 2", 2);
        priorityQueue.Enqueue("Item 3", 2);
        priorityQueue.Enqueue("Item 4", 3);

        string[] expectedResult = ["Item 1", "Item 2", "Item 3", "Item 4"];

        List<string> actualResult = [];

        for (int i = 0; i < 4; i++)
        {
            actualResult.Add(priorityQueue.Dequeue());
        }
        Assert.AreEqual(expectedResult.Length, actualResult.Count);

        for (int i = 0; i < expectedResult.Length; i++)
        {
            Assert.AreEqual(expectedResult[i], actualResult[i]);
        }
    }

    // Add more test cases as needed below.
}