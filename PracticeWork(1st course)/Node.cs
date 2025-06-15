using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeWork_1st_course_
{
    public class Node
    {
        public RealEstate Data { get; set; }
        public Node? Next { get; set; }
        public Node? Prev { get; set; }

        public Node(RealEstate data)
        { 
            Data = data;
            Next = null;
            Prev = null;
        }
    }
}
