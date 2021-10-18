using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_953502_CHIZHIK.Entities
{
    public class BookGroup
    {
        public int BookGroupId { get; set; }
        public string GroupName { get; set; }
        /// <summary>
        /// Навигационное свойство 1-ко-многим
        /// </summary>
        public List<Book> Books { get; set; }

    }
}
