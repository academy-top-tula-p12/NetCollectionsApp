using NetCollectionsApp;
using System.Collections.Generic;
using System.Collections.ObjectModel;

//ObservableCollection<string> oc = new();

Stack<int> stack = new Stack<int>();
Queue<string> queue = new Queue<string>();

stack.Push(100);
stack.Push(200);
stack.Push(300);

foreach (var item in stack)
    Console.WriteLine(item);

while(stack.Count > 0)
    Console.Write($"{stack.Pop()} ");
Console.WriteLine();


queue.Enqueue("AAAAA");
queue.Enqueue("BBBBB");
queue.Enqueue("CCCCC");

foreach (var item in queue)
    Console.WriteLine(item);

while (queue.Count > 0)
    Console.Write($"{queue.Dequeue()} ");
Console.WriteLine();


