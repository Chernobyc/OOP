using System;

class Program
{
    static void Main(string[] args)
    {
        InvoiceModel invoice = new InvoiceModel
        {
            InvoiceNumber = "EWD0034299",
            Date = new DateTime(2023, 04, 07),
            From = new ContactInfo
            {
                Name = "Albert Heights",
                Email = "anthony@tribuilders.com",
                Phone = "+1539567014",
                Address = "15 Paper Street, Toronto Canada"
            },
            To = new ContactInfo
            {
                Name = "Varela Camelia",
                Email = "samweitzel@intdesigns.com",
                Phone = "+1541267215",
                Address = "23 Markham, Toronto Canada"
            },
            Items = new List<InvoiceItem>
            {
                new InvoiceItem { Id = "01", Name = "logo design", Description = "", UnitPrice = 150, Quantity = 2, Total = 320 },
                new InvoiceItem { Id = "02", Name = "stiker design", Description = "", UnitPrice = 20, Quantity = 5, Total = 150 },
                new InvoiceItem { Id = "03", Name = "3 fold brochure design", Description = "", UnitPrice = 200, Quantity = 1, Total = 210 },
                new InvoiceItem { Id = "04", Name = "custom icons", Description = "", UnitPrice = 25, Quantity = 4, Total = 100 },
                new InvoiceItem { Id = "05", Name = "packaging design", Description = "", UnitPrice = 150, Quantity = 1, Total = 150 },
                new InvoiceItem { Id = "06", Name = "buisness card printing", Description = "", UnitPrice = 3, Quantity = 50, Total = 150 }
            },
            SubTotal = 1070,
            TaxRate = 100,
            Discount = 55,
            ShippingHandling = 30,
            GrandTotal = 1075,
            PaymentMethods = new List<string> { "PayPal", "Visa", "Credit Card", "Master Card" }
        };
    }
}
