using UnityEngine;

namespace OrdersSystem
{
    public class OrderNumber
    {
        public int Number { get; private set; } = Random.Range(0, 999999);

        public override string ToString()
        {
            string orderNumberString = Number.ToString();
            
            if (orderNumberString.Length < 6)
            {
                for (int i = 0; i < 6 - orderNumberString.Length; i++)
                {
                    orderNumberString = orderNumberString.Insert(0, "0");
                }
            }

            return orderNumberString;
        }
    }
}