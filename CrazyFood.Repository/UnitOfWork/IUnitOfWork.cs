using CrazyFood.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.Repository.ListOfRestaurants;

namespace CrazyFood.Repository.UnitOfWork
{
    public interface IUnitOfWork
    {
        #region Propertry
        IListOfRestaurantRepositary ListOfRestaurantRepositary { get; }
       
        #endregion

        #region Method
        Task Save();
        #endregion
    }
}
