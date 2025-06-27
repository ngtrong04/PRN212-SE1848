using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeViewWpfApp.models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public override string ToString()
        {
            return Id + "\t"+ "\t"+ "\t" + Name;
        }
        public Dictionary<int, Product> Products { get; set; } 
        public Category()
        {
            Products = new Dictionary<int, Product>();
            
        }
    }
}
