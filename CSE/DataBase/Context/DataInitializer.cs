using System;
using System.Diagnostics;
using System.Linq;
using DataBase.Models;
using DataBase.Repositories;

namespace DataBase.Context
{
    public class DataInitializer
    {
        private readonly DataContext _dataContext;
        private readonly RecordRepository _recordRepository;
        private readonly ProductRepository _productRepository;
        public DataInitializer(DataContext context, ProductRepository pr, RecordRepository rr)
        {
            _dataContext = context;
            _productRepository = pr;
            _recordRepository = rr;
        }

        public async void InitializeData()
        {
           // _dataContext.Database.EnsureCreated();
           /* if (_dataContext.Stores.Any())
            {
                Debug.WriteLine("EXISTS!");
                return;
            }*/
            var stores = new[]
            {
                new Store { Name = "Maxima"},
                new Store { Name = "Iki"},
                new Store { Name = "Rimi"},
                new Store { Name = "Lidl"},
                new Store { Name = "Norfa"}
            };
            /*foreach (var store in stores)
            {
                _dataContext.Stores.Add(store);
                Debug.WriteLine(store.Id+" "+store.Name);
            }
            
            _dataContext.SaveChanges();
            */

            var products = new[]
            {
                new Product {Name="Kiausiniai"},
                new Product {Name = "Pienas"},
                new Product {Name = "Sokoladas Milka su riesutais"},
                new Product {Name = "Saldyta pica su kumpiu ir grybais"}
            };

         /*   foreach (var product in products)
            {
                _dataContext.Products.Add(product);
            }
            */
             //_productRepository.InsertRange(products.ToList());
            var records = new[]
            {
                new Record
                {
                    Price = 0.12m,
                    Product = products[1],
                    Quantity = 2,
                    Store = stores[0],  
                    TimeStamp = DateTime.Now
                },
                new Record
                {
                    Price = 1.2m,
                    Product = products[2],
                    Quantity = 4,
                    Store = stores[0],
                    TimeStamp = DateTime.Now
                },
                new Record
                {
                    Price = 1m,
                    Product = products[3],
                    Quantity = 1,
                    Store = stores[0],
                    TimeStamp = DateTime.Now
                }
            };
            _dataContext.Records.AddRange(records.ToList());
            _dataContext.Records.RemoveRange(records);
            _dataContext.SaveChanges();
        }
    }
}
