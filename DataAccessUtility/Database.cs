﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace DataAccessUtility
{
    interface IDatabaseItems
    {
        string GetConnectionString();
        void SetConnection(string value);
        DataTable CreateTable(string sql);

        void RunSql(string strSQL, IDataParameter sqlParam);
        void RunSql(string strSQL, IDataParameter[] sqlParams);
        
    }

    public abstract class DataBase : IDatabaseItems
    {
        protected string _ConnectionString { get; set; }

        /// <summary>
        /// Gets the connection String for the Database
        /// </summary>
        /// <returns>String: Connection String</returns>
        public abstract string GetConnectionString();
        
        /// <summary>
        /// Sets the connection String of the Database
        /// </summary>
        /// <param name="value">Connection String</param>
        public abstract void SetConnection(string value);

        public abstract DataTable CreateTable(string sql);

        public abstract IDataParameter CreateParam(string paramName, object paramValue);
        public abstract void RunSql(string strSQL, IDataParameter SqlParam);
        public abstract void RunSql(string strSQL, IDataParameter[] sqlParams);

    }



}
