using System.Data;
using System.Net;

abstract class Delivery
{
    public string Address;                //Базовый класс доставки
}

class Адрес
{
    public string Street { get; set; }
    public string City { get; set; }           //Свойства Адреса
    public string PostalCode { get; set; }
}

class HomeDelivery : Delivery
{
    public string CourierName { get; set; }    //Имя Курьера
}

class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }     //Название товара цена
}

class OrderItem
{
    public Product Product { get; set; }  //Допалнительные свойства товара (Кол-во,акции на товары)
    public int Quantity { get; set; }
}

class PickPointDelivery : Delivery
{
    public string PickPointId { get; set; }       //Другие свойства доставки

}

class ShopDelivery : Delivery
{
    public string ShopName { get; set; }      //Свойства доставки в магазин
}

class Order<TDelivery> where TDelivery : Delivery
{
    public TDelivery Delivery { get; set; }
    public int OrderNumber { get; set; }
    public List<OrderItem> OrderItems { get; set; }
    public decimal TotalAmount { get; set; }

    public void DisplayDeliveryAddress()
    {
        Console.WriteLine(Delivery.Address);
    }

    public void AddOrderItem(Product product, int quantity)
    {
        OrderItems.Add(new OrderItem { Product = product, Quantity = quantity });
    }

    public void CalculateTotalAmount()
    {
        TotalAmount = OrderItems.Sum(item => item.Product.Price * item.Quantity);
    }
}
//Пример использования


//class Program
//{
//    static void Main()
//    {
//        // Создание заказа с доставкой на дом
//        var homeDeliveryOrder = new Order<HomeDelivery>
//        {
//            Delivery = new HomeDelivery
//            {
//                Address = new Address { Street = "123 Main St", City = "City", PostalCode = "12345" },
//                CourierName = "FastCourier Inc."
//            },
//            OrderNumber = 1,
//            OrderItems = new List<OrderItem>
//            {
//                new OrderItem { Product = new Product { Name = "Smartphone", Price = 599.99m }, Quantity = 1 },
//                new OrderItem { Product = new Product { Name = "Headphones", Price = 99.99m }, Quantity = 2 }
//            }
//        };

//        homeDeliveryOrder.DisplayDeliveryAddress();
//        homeDeliveryOrder.AddOrderItem(new Product { Name = "Keyboard", Price = 49.99m }, 1);
//        homeDeliveryOrder.CalculateTotalAmount();
//        Console.WriteLine($"Total amount: {homeDeliveryOrder.TotalAmount}");

//        // Создание заказа с доставкой в пункт выдачи
//        var pickPointDeliveryOrder = new Order<PickPointDelivery>
//        {
//            Delivery = new PickPointDelivery
//            {
//                Address = new Address { Street = "456 Elm St", City = "Town", PostalCode = "54321" },
//                PickPointId = "PP123"
//            },
//            OrderNumber = 2,
//            OrderItems = new List<OrderItem>
//            {
//                new OrderItem { Product = new Product { Name = "Tablet", Price = 399.99m }, Quantity = 1 }
//            }
//        };

//        pickPointDeliveryOrder.DisplayDeliveryAddress();
//        pickPointDeliveryOrder.CalculateTotalAmount();
//        Console.WriteLine($"Total amount: {pickPointDeliveryOrder.TotalAmount}");

//        // Таким образом, система классов позволяет моделировать разные типы заказов и доставки в интернет-магазине.
//    }
//}
