﻿namespace FoodShortage
{
    public interface IBuyer
    {
        public int Food { get; set; }
        public string Name { get; set; }

        void BuyFood();
    }
}
