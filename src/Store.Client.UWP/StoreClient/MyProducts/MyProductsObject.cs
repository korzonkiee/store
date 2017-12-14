using StoreClient.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreClient.MyProducts
{
    static class MyProductsObject
    {
        static public ObservableCollection<Product> Products { get; set; }
    }
}
