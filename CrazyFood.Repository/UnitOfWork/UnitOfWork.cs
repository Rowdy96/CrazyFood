using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CrazyFood.DomainModel.Data;
using CrazyFood.Repository.ListOfRestaurants;


namespace CrazyFood.Repository.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        #region Private Variables

        #region Dependencies
        private readonly CrazyFoodContext _context;
        private IListOfRestaurantRepositary _listOfRestaurantRepositary;
        #endregion

        #endregion

        #region Public propertry
        public IListOfRestaurantRepositary ListOfRestaurantRepositary
        {
            get
            {
                _listOfRestaurantRepositary = new ListOfRestaurantRepositary(_context);
                return _listOfRestaurantRepositary;
            }
        }
        
        #endregion

        #region Construcor 
        public UnitOfWork(CrazyFoodContext context)
        {
            this._context = context;
        }
        #endregion
        #region Public Method

        public async Task Save()
        {
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}
