using System;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {

        private List<GiftBase> _gifts;
        public CompositeGift(string name , int price) : base(name,price)
        {
            _gifts = new List<GiftBase>();
        }

        public override int CalculateTotalPrice()
        {
            Console.WriteLine($"{_name} contains the following products with prices:");

            return _gifts.Sum(gift => gift.CalculateTotalPrice());
        }

        public void Add(GiftBase gift)
        {
            _gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            _gifts.Remove(gift);
        }
    }
}