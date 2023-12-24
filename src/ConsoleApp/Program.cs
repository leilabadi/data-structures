// See https://aka.ms/new-console-template for more information
using DataStructures.DataStructureLibrary;

StackBackedQueueTest();

static void StackBackedQueueTest()
{
    var queue = new StackBackedQueue<int>();
    queue.Enqueue(1);
    Console.WriteLine(queue.Peak());
    queue.Enqueue(2);
    queue.Enqueue(3);
    Console.WriteLine(queue.Peak());
    queue.Dequeue();
    Console.WriteLine(queue.Peak());
    queue.Enqueue(4);
    Console.WriteLine(queue.Peak()); 
    queue.Dequeue();
    Console.WriteLine(queue.Peak()); 
    queue.Dequeue();
    queue.Enqueue(5);
    queue.Enqueue(6);
    queue.Dequeue();
    queue.Enqueue(7);
}