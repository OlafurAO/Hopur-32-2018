using System;
using System.Linq;
using System.Collections.Generic;
using BookStore.Data;
using BookStore.Data.EntityModels;
using BookStore.Models;
using BookStore.Models.ViewModels;
using BookStore.Repositories;

namespace BookStore.Services
{
    public class OrderHistoryService
    {
        DataContext _orderHistoryDb;

        public OrderHistoryService()
        {
            _orderHistoryDb = new DataContext();
        }

        public void SaveOrder(Order order)
        {
            _orderHistoryDb.AddRange( new OrderHistory { Order = order });
                
            _orderHistoryDb.SaveChanges();
        }

        public List<OrderHistory> GetOrderHistory()
        {
            var orders = (from a in _orderHistoryDb.OrderHistory
                          select a).ToList();
            return orders;
        }
    }
}  