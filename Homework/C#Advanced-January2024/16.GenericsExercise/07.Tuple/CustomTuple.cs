﻿namespace _07.Tuple
{
    public class CustomTuple<T1, T2>
    {
        public CustomTuple(T1 firstItem, T2 secondItem)
        {
            FirstItem = firstItem;
            SecondItem = secondItem;
        }

        public T1 FirstItem { get; set; }
        public T2 SecondItem { get; set; }

        public override string ToString()
        {
            return $"{FirstItem} -> {SecondItem}";
        }
    }
}
