using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace WEB_953502_CHIZHIK.Blazor.Client.Models
{
    public class ListViewModel
    {
        [JsonPropertyName("bookId")]
        public int BookId { get; set; } // id блюда
        [JsonPropertyName("bookName")]
        public string BookName { get; set; } // название блюда

    }
}
