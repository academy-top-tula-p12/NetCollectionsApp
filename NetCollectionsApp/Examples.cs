using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCollectionsApp
{
    static class Examples
    {
        static public void IndexRangeExample()
        {
            List<int> intList = new() { 5, 11, 9, 21, 65, 2 };

            Console.WriteLine(intList[intList.Count - 2]);
            Index index = 2;
            Index index2 = ^2;
            Console.WriteLine(intList[index]);
            Console.WriteLine(intList[^1]);

            Range range1 = new Range(2, 5);
            Range range2 = 2..4;
            int start = 2;
            int end = 4;
            Range range3 = ..end;
            Range range4 = index2..;

            var subList = intList[range4];
            foreach (var item in subList)
                Console.Write($"{item} ");
            Console.WriteLine();
        }

        static public void DictionaryExample()
        {
            Dictionary<string, int> regions = new Dictionary<string, int>()
            {
                /*{ "Tula", 71 },
                { "Moscow", 90 },*/
                ["Tula"] = 71,
                ["Moscow"] = 90
            };

            KeyValuePair<string, int> kaluga = new KeyValuePair<string, int>("Kaluga", 40);
            regions.Add(kaluga.Key, kaluga.Value);

            foreach (var region in regions)
                Console.WriteLine($"Region: {region.Key}, Code: {region.Value}");

            if (regions.TryGetValue("Moscow", out int code))
                Console.WriteLine(code);

            regions.TryAdd("Moscow", 95);

            foreach (var region in regions)
                Console.WriteLine($"Region: {region.Key}, Code: {region.Value}");

            regions["Moscow"] = 95;

            foreach (var region in regions)
                Console.WriteLine($"Region: {region.Key}, Code: {region.Value}");

            regions["Voroneg"] = 36;

            foreach (var region in regions)
                Console.WriteLine($"Region: {region.Key}, Code: {region.Value}");
        }

        static public void ListExample()
        {
            Random random = new Random();

            List<int> listInt = new List<int>();
            List<int> listInt2 = new(10);
            List<int> listInt3 = [];

            for (int i = 0; i < 10; i++)
                listInt.Add(random.Next() % 100);

            foreach (int i in listInt)
                Console.Write($"{i} ");
            Console.WriteLine();

            for (int i = 0; i < listInt.Count; i++)
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

        }

        static public void ArrayExample()
        {
            Random random = new Random();

            int[] arrayInt = new int[10];
            for (int i = 0; i < arrayInt.Length; i++)
                arrayInt[i] = random.Next() % 100;

            foreach (int item in arrayInt)
                Console.Write($"{item} ");
            Console.WriteLine();

            Array.Sort(arrayInt);

            foreach (int item in arrayInt)
                Console.Write($"{item} ");
            Console.WriteLine();

            Console.WriteLine(Array.BinarySearch(arrayInt, 10));

            //Array.Clear(arrayInt);
            //Array.Fill(arrayInt, 100);
            //foreach (int item in arrayInt)
            //    Console.Write($"{item} ");
            //Console.WriteLine();

            Console.WriteLine(Array.Exists(arrayInt, (item) => item < 0));
            Console.WriteLine(Array.Find(arrayInt, (item) => item % 2 == 0));
            Console.WriteLine(Array.FindIndex(arrayInt, (item) => item % 2 == 0));
            // FindLast, FindLastIndex
            var oddItems = Array.FindAll(arrayInt, (item) => item % 2 != 0);

            foreach (int item in oddItems)
                Console.Write($"{item} ");
            Console.WriteLine();

            Array.Reverse(arrayInt);

            foreach (int item in arrayInt)
                Console.Write($"{item} ");
            Console.WriteLine();
        }

        static public void HashtableExample()
        {
            Hashtable hashtable = new Hashtable();

            hashtable.Add("str", "Hello");
            hashtable.Add("int", 123);
            hashtable.Add("dbl", 356.89);
            hashtable.Add("int2", 12234233);
            hashtable.Add("std", new Student() { Name = "Kim" });

            foreach (var item in hashtable)
                Console.WriteLine($"{item} - {item.GetHashCode()}");
        }

        static public void CollectionInterfacesExample()
        {
            Student bob = new Student() { Name = "Bob" };
            Student joe = new Student() { Name = "Joe" };
            Student sam = new Student() { Name = "Sam" };

            Group group = new(3);
            group.Students[0] = bob;
            group.Students[1] = joe;
            group.Students[2] = sam;

            foreach (Student student in group)
                Console.WriteLine(student.Name);
        }

        static public void ArrayListExample()
        {
            ArrayList arrayList = new ArrayList();

            arrayList.Add("Hello");
            arrayList.Add(123);
            arrayList.Add(433.546);
            arrayList.Add(new Student() { Name = "Mark" });

            foreach (var obj in arrayList)
                Console.WriteLine(obj);
        }
    }

    class Student
    {
        public string? Name { get; set; }
    }

    class Group : IEnumerable
    {
        public string? Title { get; set; }
        public Student[] Students { get; set; } = null!;

        public Group(int size)
        {
            Students = new Student[size];
        }

        public IEnumerator GetEnumerator()
        {
            return new GroupIterator(this);
        }
    }

    class GroupIterator : IEnumerator
    {
        Group group;
        int index;

        public GroupIterator(Group group)
        {
            this.group = group;
            index = -1;
        }

        public object Current => group.Students[index];

        public bool MoveNext()
        {
            if (index < group.Students.Length)
                index++;
            return index < group.Students.Length;
        }

        public void Reset()
        {
            index = -1;
        }
    }
}
