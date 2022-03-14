using System;
using System.Collections.Generic;

namespace RestaurantSystem.Models
{
    public class Table
    {
        private static int currentTableNo = 0;
        public int TableNo { get; internal set; }
        public int SeatsAmount { get; internal set; }
        public bool IsOccupied { get; set; }
        public List<Menu> OrderedItems { get;  set; }

        public Table()
        {
            TableNo = GetNextTableNo();
            SeatsAmount = GenerateRandSeatsAmount();
            IsOccupied = false;
            OrderedItems = new List<Menu>();
        }
        public void AddItemToOrder(Menu item)
        {
            OrderedItems.Add(item);
        }
        public void ClearOrderedItems()
        {
            OrderedItems.Clear();
        }
        protected int GetNextTableNo()
        {
            return ++currentTableNo;
        }
        protected int GenerateRandSeatsAmount()
        {
            var rand = new Random();
            return rand.Next(2,7);
        }
        public override string ToString()
        {
            return $"Tabele No.{TableNo};  Seats amount - {SeatsAmount};  Is Occupied - {IsOccupied}";
        }
       
    }
}
