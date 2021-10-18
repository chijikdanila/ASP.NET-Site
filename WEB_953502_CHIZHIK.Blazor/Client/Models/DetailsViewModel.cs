using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WEB_953502_CHIZHIK.Blazor.Client.Models
{
    public class DetailsViewModel
    {
        [JsonPropertyName("bookName")]
        public string BookName { get; set; } // название книги
        [JsonPropertyName("author")]
        public string Author { get; set; } // автор книги
        [JsonPropertyName("price")]
        public int Price { get; set; } // цен книги
        [JsonPropertyName("image")]
        public string Image { get; set; } // имя файла изображения
    }
}
