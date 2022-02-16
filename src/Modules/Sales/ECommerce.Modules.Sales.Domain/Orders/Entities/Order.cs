﻿using ECommerce.Modules.Sales.Domain.Orders.Exceptions;
using ECommerce.Shared.Abstractions.Kernel.Types;

namespace ECommerce.Modules.Sales.Domain.Orders.Entities
{
    public class Order : AggregateRoot
    {
        public string OrderNumber { get; private set; }
        public OrderItem OrderItem { get; private set; }
        public decimal Cost { get; private set; }
        public bool Paid { get; private set; }

        public IEnumerable<OrderItem> OrderItems => _orderItems;
        private ICollection<OrderItem> _orderItems;

        public Order(AggregateId id, string orderNumber, OrderItem orderItem, decimal cost, bool paid = false, ICollection<OrderItem> orderItems = null)
        {
            ValidateOrderNumber(orderNumber);
            ValidateOrderItem(orderItem);
            ValidateCost(cost);
            Id = id;
            OrderNumber = orderNumber;
            OrderItem = orderItem;
            Cost = cost;
            Paid = paid;
            _orderItems = orderItems;
        }

        public static Order Create(string paymentNumber, OrderItem orderItem, decimal cost)
        {
            var order = new Order(Guid.NewGuid(), paymentNumber, orderItem, cost);
            return order;
        }

        public void AddOrderItems(IEnumerable<OrderItem> orderItems)
        {
            if (orderItems is null)
            {
                throw new OrderItemsCannotBeNullException();
            }

            if (!orderItems.Any())
            {
                return;
            }

            foreach(var orderItem in orderItems)
            {
                _orderItems.Add(orderItem);
                orderItem.AddOrder(Id);
            }
        }

        public void AddOrderItem(OrderItem orderItem)
        {
            if (orderItem is null)
            {
                throw new OrderItemCannotBeNullException();
            }

            _orderItems.Add(orderItem);
            orderItem.AddOrder(Id);
        }

        private static void ValidateOrderNumber(string orderNumber)
        {
            if (string.IsNullOrWhiteSpace(orderNumber))
            {
                throw new OrderNumberCannotBeEmptyException();
            }
        }

        private static void ValidateOrderItem(OrderItem orderItem)
        {
            if (orderItem is null)
            {
                throw new OrderItemCannotBeNullException();
            }
        }

        private static void ValidateCost(decimal cost)
        {
            if (cost < decimal.Zero)
            {
                throw new OrderCostCannotBeNegativeException(cost);
            }
        }
    }
}
