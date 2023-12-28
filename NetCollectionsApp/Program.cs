using NetCollectionsApp;
using System.Collections.Generic;

Random random = new Random();

List<int> listInt = new List<int>();
List<int> listInt2 = new(10);
List<int> listInt3 = [];

for (int i = 0; i < 10; i++)
    listInt.Add(random.Next() % 100);

foreach(int i in listInt)
    Console.Write($"{i} ");
Console.WriteLine();

for(int i = 0; i < listInt.Count; i++)
    Console.Write($"{listInt[i]} ");

/*
 * void Add(T item) - add to back list
 * void AddRange(IEnumerable<T> collection) - add other collection
 
 * int BinarySearch(T item) - return index finded item or number < 0
 
 * void CopyTo(T[] array) - copy list to Array
 * bool Contains(T item) - true if item contains in list
 * void Clear() - deleted all items from list
 
 * T? Find(Predicate<T> match) - return reference to item
 * T? FindLast(Predicate<T> match) - return reference to item
 * List<T> FindAll(Predicate<T> match) - return list
 
 * int IndexOf(T item) - return index of item or number < 0
 * int LastIndexOf(T item) - return index of item or number < 0
 
 * List<T> GetRange(int index, int count) - return range length of count, from index
 
 * void Insert(int index, T item) - indert item to list at index position
 * void InsertRange(int index, IEnumerable<T> collection) - indert collection to list at index position
 
 * bool Remove(T item) - delete item from list (true if item contains)
 * void RemoveAt(int index) - delete item at index position
 * void RemoveRange(int index, int count) - delete rande from index and count items
 * 
 * void Reverse()
 * void Reverse(int index, int count)
 * void Sort()
 * void Sort(IComparer<T> comparer)
 * 
 */






