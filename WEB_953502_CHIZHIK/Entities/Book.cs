using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_953502_CHIZHIK.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public int Price { get; set; }
        public string Image { get; set; } 

        // Навигационные свойства
        /// <summary>
        /// группа блюд (например, супы, напитки и т.д.)
        /// </summary>
        public int BookGroupId { get; set; }
        public BookGroup Group { get; set; }
    }
}
