using DAL.GenericRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;

namespace DAL.UnitOfWork
{
    /// <summary>
    /// Unit of work class responsible for DB transactions
    /// </summary>
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region Private member variables...

        private TorEntities _context = null;
        private GenericRepository<TorUser> _userRepository;
        private GenericRepository<Token> _tokenRepository;
        private GenericRepository<Customer> _cutomerRepository;
        private GenericRepository<Insurance> _insuranceRepository;

        #endregion
        public UnitOfWork()
        {
            _context = new TorEntities();
        }

        #region Public Repository Creation properties...

        /// <summary>
        /// Get/Set Property for product repository.
        /// </summary>
        public GenericRepository<TorUser> UserRepository
        {
            get
            {
                if (this._userRepository == null)
                    this._userRepository = new GenericRepository<TorUser>(_context);
                return _userRepository;
            }
        }

        public GenericRepository<Token> TokenRepository
        {
            get
            {
                if (this._tokenRepository == null)
                    this._tokenRepository = new GenericRepository<Token>(_context);
                return _tokenRepository;
            }
        }

        public GenericRepository<Customer> CustomerRepository
        {
            get
            {
                if (this._cutomerRepository == null)
                    this._cutomerRepository = new GenericRepository<Customer>(_context);
                return _cutomerRepository;
            }
        }

        public GenericRepository<Insurance> InsuranceRepository
        {
            get
            {
                if (this._insuranceRepository == null)
                    this._insuranceRepository = new GenericRepository<Insurance>(_context);
                return _insuranceRepository;
            }
        }

        #endregion

        #region Public member methods...

        /// <summary>
        /// Save method.
        /// </summary>
        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e)
            {
                var outputLines = new List<string>();
                foreach (var eve in e.EntityValidationErrors)
                {
                    outputLines.Add(string.Format("{0} : Entity of type \"{1}\" in state \"{2}\" has following validation errors:", DateTime.Now, eve.Entry.Entity.GetType().Name,
                        eve.Entry.State));
                    foreach (var ve in eve.ValidationErrors)
                    {
                        outputLines.Add(string.Format("- Property: \"{0}\", Error: \"{1}\"", ve.PropertyName, ve.ErrorMessage));
                    }
                }
                System.IO.File.AppendAllLines(@"C:\errors.txt", outputLines);

                throw e;
            }
        }

        public List<SearchCustomer_p_Result> ExtanetSearch(string efSalesRefId, string lastName, string firstName, string startYear,
            string startMonth, string startDay, string endYear, string endMonth, string endDay, string dobYear,
            string dobMonth, string dobDay, string salesCountry, string program, string destinationCountry,
            string policy, string aetnaId)
        {
            return _context.SearchCustomer_p(efSalesRefId, lastName, firstName, startYear, startMonth, startDay,
                endYear, endMonth, endDay, dobYear, dobMonth, dobDay, salesCountry, program, destinationCountry, policy, aetnaId).ToList();
        }

        #endregion

        #region Implementing IDiosposable...

        #region private dispose variable declaration...
        private bool disposed = false;
        #endregion

        /// <summary>
        /// Protected Virtual Dispose method
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Debug.WriteLine("UnitOfWork is being disposed");
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        /// <summary>
        /// Dispose method
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }


        #endregion

    }
}
