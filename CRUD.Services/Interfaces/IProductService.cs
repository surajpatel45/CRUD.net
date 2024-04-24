using CRUD.Domain;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.Services.Interfaces
{
    internal interface IProductService
    {
        Task<List<User>> ViewProductsAsync();
        Task<string> AddProductAsync(User product);
        Task<string> ModifyProductAsync(int id, User product);
        Task<string> RemoveProductAsync(int id);
        Task<User> GetProductByIdAsync(int id);
    }
}
