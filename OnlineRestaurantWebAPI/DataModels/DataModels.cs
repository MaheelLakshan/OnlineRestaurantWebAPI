using System.ComponentModel.DataAnnotations;

namespace OnlineRestaurantWebAPI.DataModels
{
    public class DataModels
    {
    }
    public class Customer
    {
        [Key]
        public int cust_ID { get; set; }
        public string name { get; set; }
        public int contact { get; set; }
        public string address { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<Payment> Payments { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }

    public class Shop
    {
        [Key]
        public int shop_ID { get; set; }
        public string name { get; set; }
        public int contact { get; set; }
        public string address { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }

    public class OrderDetails
    {
        [Key]
        public int order_ID { get; set; }
        public int shop_ID { get; set; }
        public int cust_ID { get; set; }
        public int food_ID { get; set; }
        public DateTime date { get; set; }
        public string status { get; set; }
        public Shop Shop { get; set; }
        public Customer Customer { get; set; }
        public Food Food { get; set; }
        public Delivery Delivery { get; set; }
        public ICollection<Payment>  Payments { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }

    public class Payment
    {
        [Key]
        public int pay_ID { get; set; }
        public int cust_ID { get; set; }
        public int order_ID { get; set; }
        public int delivery_ID { get; set; }
        public int amount { get; set; }
        public DateTime date { get; set; }
        public Customer Customer { get; set; }
        public OrderDetails OrderDetails { get; set; }
        public Delivery Delivery { get; set; }
        
    }

    public class Menu
    {
        [Key]
        public int menu_ID { get; set; }
        public int food_ID { get; set; }
        public string details { get; set; }
        public Food Food { get; set; }
    }

    public class Food
    {
        [Key]
        public int food_ID { get; set; }
        public string name { get; set; }
        public int status { get; set; }
        public int price { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public ICollection<Menu> Menus { get; set; }
    }

    public class Delivery
    {
        [Key]
        public int delivery_ID { get; set; }
        public int order_ID { get; set; }
        public DateTime date { get; set; }
        public OrderDetails OrderDetails { get; set; }
        public ICollection<Payment> Payments { get; set; }
    }

    public class Transaction
    {
        [Key]
        public int trans_ID { get; set; }
        public DateTime trans_date { get; set; }
        public int cust_ID { get; set; }
        public int shop_ID { get; set; }
        public int order_ID { get; set; }
        public DateTime report_date { get; set; }
        public Customer Customer { get; set; }
        public Shop Shop { get; set; }
        public OrderDetails OrderDetails { get; set; }
    }
}
