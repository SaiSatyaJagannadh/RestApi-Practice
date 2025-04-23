using ApplicationCore.Entities;

namespace ApplicationCore.Contracts.Repositories;

public interface IProductRepository: IRepository<Product>
{
    //for base repository in infras if functions we use common we use them 
    //if we need extra functions then we can implemeny the methods here 
    
    
}