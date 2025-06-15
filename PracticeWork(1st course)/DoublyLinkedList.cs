using PracticeWork_1st_course_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PracticeWork_1st_course_
{
    public class DoublyLinkedList
    {
        private Node? head;
        private Node? tail;
        private int count;

        public int Count => count;

        public void AddAt(int index, RealEstate data)
        {
            if (index < 0 || index > count)
                throw new ArgumentOutOfRangeException(nameof(index));

            var newNode = new Node(data);

            if (index == 0)
            {
                newNode.Next = head;
                if (head != null) head.Prev = newNode;
                head = newNode;
                if (tail == null) tail = head;
            }
            else if (index == count)
            {
                newNode.Prev = tail;
                if (tail != null) tail.Next = newNode;
                tail = newNode;
            }
            else
            {
                var current = head;
                for (int i = 0; i < index; i++)
                    current = current?.Next;

                newNode.Next = current;
                newNode.Prev = current?.Prev;
                current!.Prev!.Next = newNode;
                current.Prev = newNode;
            }
            count++;
        }

        public void RemoveAt(int index)
        {
            if (index < 0 || index >= count)
                throw new ArgumentOutOfRangeException(nameof(index));

            if (index == 0)
            {
                head = head?.Next;
                if (head != null) head.Prev = null;
                if (head == null) tail = null;
            }
            else
            {
                var current = head;
                for (int i = 0; i < index; i++)
                    current = current?.Next;

                if (current?.Prev != null)
                    current.Prev.Next = current.Next;
                if (current?.Next != null)
                    current.Next.Prev = current.Prev;

                if (current == tail)
                    tail = current.Prev;
            }
            count--;
        }

        public RealEstate this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                var current = head;
                for (int i = 0; i < index; i++)
                    current = current?.Next;

                return current!.Data;
            }
            set
            {
                if (index < 0 || index >= count)
                    throw new ArgumentOutOfRangeException(nameof(index));

                var current = head;
                for (int i = 0; i < index; i++)
                    current = current?.Next;

                current!.Data = value;
            }
        }

        public void SortByPriceDescending()
        {
            if (head == null) return;

            var current = head;
            while (current != null)
            {
                var maxNode = current;
                var nextNode = current.Next;

                while (nextNode != null)
                {
                    if (nextNode.Data.Price > maxNode.Data.Price)
                        maxNode = nextNode;

                    nextNode = nextNode.Next;
                }

                if (maxNode != current)
                {
                    (current.Data, maxNode.Data) = (maxNode.Data, current.Data);
                }

                current = current.Next;
            }
        }

        public IEnumerable<RealEstate> Search()
        {
            var result = new List<RealEstate>();
            var current = head;

            while (current != null)
            {
                if (current.Data.Type == PropertyType.Apartment &&
                    !current.Data.Sold &&
                    current.Data.Price >= 200000 &&
                    current.Data.Price <= 500000)
                {
                    result.Add(current.Data);
                }
                current = current.Next;
            }

            return result;
        }

        public void PrintList()
        {
            Console.WriteLine($"{"Type",-10} | {"Price",10} | {"Sold",5}");
            Console.WriteLine(new string('-', 30));
            var current = head;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Next;
            }
            Console.WriteLine();
        }

        public void PrintFromEnd()
        {
            Console.WriteLine("List from end:");
            Console.WriteLine($"{"Type",-10} | {"Price",10} | {"Sold",5}");
            Console.WriteLine(new string('-', 30));
            var current = tail;
            while (current != null)
            {
                Console.WriteLine(current.Data);
                current = current.Prev;
            }
            Console.WriteLine();
        }

        public void Serialize(string filePath)
        {
            var list = new List<RealEstate>();
            var current = head;
            while (current != null)
            {
                list.Add(current.Data);
                current = current.Next;
            }
            var json = JsonSerializer.Serialize(list, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void Deserialize(string filePath)
        {
            if (!File.Exists(filePath)) return;

            var json = File.ReadAllText(filePath);
            var list = JsonSerializer.Deserialize<List<RealEstate>>(json);

            head = tail = null;
            count = 0;

            if (list != null)
            {
                foreach (var item in list)
                {
                    AddAt(count, item);
                }
            }
        }
    }
}
