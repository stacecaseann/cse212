/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService
{
    public static void Run()
    {
        // Example code to see what's in the customer service queue:
        var cs = new CustomerService(10);
        Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: User adds invalid size
        // Expected Result: Size 10
        Console.WriteLine("Test 1");
        var invalidCs = new CustomerService(-1);
        Console.WriteLine(invalidCs);
        // Defect(s) Found: none

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add customers to the queue
        // Expected Result: Customers should be in the queue
        Console.WriteLine("Test 2");
        var addCs = new CustomerService(5);
        addCs.AddNewCustomer();
        Console.WriteLine(addCs);

        // Defect(s) Found: none

        Console.WriteLine("=================");


        // Test 3
        // Scenario: Add more customers to the queue than allowed
        // Expected Result: Should get an error
        Console.WriteLine("Test 3");
        var fullCs = new CustomerService(1);
        fullCs.AddNewCustomer();
        fullCs.AddNewCustomer();
        Console.WriteLine(fullCs);

        // Defect(s) Found: I could add the customer over the limit
        Console.WriteLine("=================");

        // Test 4
        // Scenario: Add a customer then serve it
        // Expected Result: Should successfully remove the customer from the queue
        Console.WriteLine("Test 4");
        var serveCs = new CustomerService(3);
        serveCs.AddNewCustomer();
        serveCs.AddNewCustomer();
        serveCs.ServeCustomer();
        Console.WriteLine(serveCs);

        // Defect(s) Found: None
        Console.WriteLine("=================");

        // Test 5
        // Scenario: Serve a customer with an empty queue
        // Expected Result: Should have an error
        Console.WriteLine("Test 5");
        var emptyQueueCs = new CustomerService(3);
        emptyQueueCs.ServeCustomer();
        Console.WriteLine(emptyQueueCs);

        // Defect(s) Found: There is an index out of bounds error
        Console.WriteLine("=================");

        // Test 6
        // Scenario: Add and serve multiple customers
        //      Add 1,2 serve 1, add 3, serve 2
        // Expected Result: customer 3 in queue
        Console.WriteLine("Test 6");
        var multipleQueue = new CustomerService(5);
        multipleQueue.AddNewCustomer();
        multipleQueue.AddNewCustomer();
        Console.WriteLine($"2 customers {multipleQueue}");
        multipleQueue.ServeCustomer();
        Console.WriteLine($"1 customer {multipleQueue}");
        multipleQueue.AddNewCustomer();
        Console.WriteLine($"2 customers {multipleQueue}");
        multipleQueue.ServeCustomer();
        Console.WriteLine($"1 customer {multipleQueue}");

        // Defect(s) Found: There is an index out of bounds error
        Console.WriteLine("=================");
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize)
    {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer
    {
        public Customer(string name, string accountId, string problem)
        {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString()
        {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer()
    {
        // Verify there is room in the service queue
        if (_queue.Count >= _maxSize)
        {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer()
    {
        if (_queue.Count == 0)
        {
            Console.WriteLine("== Not Good Stuff ==");
            return;
        }
        var customer = _queue[0];
        Console.WriteLine($"Serve customers {customer}");
        _queue.RemoveAt(0);

    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString()
    {
        return $"[size={_queue.Count} max_size={_maxSize} => " + string.Join(", ", _queue) + "]";
    }
}