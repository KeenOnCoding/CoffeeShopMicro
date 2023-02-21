﻿namespace CoffeeShopMicro.Barista.Domain.Entities
{
    public class MenuItem
    {
        public Guid Id { get; set; }

        public int Number { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}
