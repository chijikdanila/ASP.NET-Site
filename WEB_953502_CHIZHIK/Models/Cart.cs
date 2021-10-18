using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WEB_953502_CHIZHIK.Entities;

namespace WEB_953502_CHIZHIK.Models
{
    public class Cart
    {
        public Dictionary<int, CartItem> Items { get; set; }
        public Cart()
        {
            Items = new Dictionary<int, CartItem>();
        }

        /// <summary>
        /// Количество объектов в корзине
        /// </summary>
        public int Count
        {
            get
            {
                return Items.Sum(item => item.Value.Quantity);
            }
        }

        /// <summary>
        /// Добавление в корзину
        /// </summary>
        /// <param name="book">добавляемый объект</param>
        public virtual void AddToCart(Book book)
        {
            // если объект есть в корзине
            // то увеличить количество
            if (Items.ContainsKey(book.BookId))
                Items[book.BookId].Quantity++;
            // иначе - добавить объект в корзину
            else
                Items.Add(book.BookId, new CartItem
                {
                    Book = book,
                    Quantity = 1
                });
        }

        /// <summary>
        /// Удалить объект из корзины
        /// </summary>
        /// <param name="id">id удаляемого объекта</param>
        public virtual void RemoveFromCart(int id)
        {
            Items.Remove(id);
        }

        /// <summary>
        /// Очистить корзину
        /// </summary>
        public virtual void ClearAll()
        {
            Items.Clear();
        }
    }

    /// <summary>
    /// Клас описывает одну позицию в корзине
    /// </summary>
    public class CartItem
    {
        public Book Book { get; set; }
        public int Quantity { get; set; }
    }
}
