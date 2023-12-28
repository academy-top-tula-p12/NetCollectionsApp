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
