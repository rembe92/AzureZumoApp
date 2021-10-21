using Microsoft.WindowsAzure.MobileServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AzureZumoApp.Persistence
{
    class MobileServiceTableWrapper<T> : IMobileServiceTable<T>
    {
        IMobileServiceTable<T> table;
        MobileServiceClient _mobileServiceClient;

        public MobileServiceTableWrapper(IMobileServiceClient mobileServiceClient)
        {
            _mobileServiceClient = (MobileServiceClient)mobileServiceClient;
            table = _mobileServiceClient.GetTable<T>();
        }

        public MobileServiceClient MobileServiceClient => _mobileServiceClient;

        public string TableName => table.TableName;

        public IMobileServiceTableQuery<T> CreateQuery()
        {
            return table.CreateQuery();
        }

        public Task DeleteAsync(T instance)
        {
            return table.DeleteAsync(instance);
        }

        public Task DeleteAsync(T instance, IDictionary<string, string> parameters)
        {
            return table.DeleteAsync(instance, parameters);
        }

        public Task<JToken> DeleteAsync(JObject instance)
        {
            return table.DeleteAsync(instance);
        }

        public Task<JToken> DeleteAsync(JObject instance, IDictionary<string, string> parameters)
        {
            return table.DeleteAsync(instance, parameters);
        }

        public IMobileServiceTableQuery<T> IncludeDeleted()
        {
            return table.IncludeDeleted();
        }

        public IMobileServiceTableQuery<T> IncludeTotalCount()
        {
            return table.IncludeTotalCount();
        }

        public Task InsertAsync(T instance)
        {
            return table.InsertAsync(instance);
        }

        public Task InsertAsync(T instance, IDictionary<string, string> parameters)
        {
            return table.InsertAsync(instance, parameters);
        }

        public Task<JToken> InsertAsync(JObject instance)
        {
            return table.InsertAsync(instance);
        }

        public Task<JToken> InsertAsync(JObject instance, IDictionary<string, string> parameters)
        {
            return table.InsertAsync(instance, parameters);
        }

        public Task<T> LookupAsync(object id)
        {
            return table.LookupAsync(id);
        }

        public Task<T> LookupAsync(object id, IDictionary<string, string> parameters)
        {
            return table.LookupAsync(id, parameters);
        }

        public IMobileServiceTableQuery<T> OrderBy<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return table.OrderBy(keySelector);
        }

        public IMobileServiceTableQuery<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<U>> ReadAsync<U>(string query)
        {
            return table.ReadAsync<U>(query);
        }

        public Task<IEnumerable<U>> ReadAsync<U>(IMobileServiceTableQuery<U> query)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> ReadAsync()
        {
            return table.ReadAsync();
        }

        public Task<JToken> ReadAsync(string query)
        {
            return table.ReadAsync(query);
        }

        public Task<JToken> ReadAsync(string query, IDictionary<string, string> parameters, bool wrapResult)
        {
            throw new NotImplementedException();
        }

        public Task RefreshAsync(T instance)
        {
            return table.RefreshAsync(instance);
        }

        public Task RefreshAsync(T instance, IDictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        public IMobileServiceTableQuery<U> Select<U>(Expression<Func<T, U>> selector)
        {
            throw new NotImplementedException();
        }

        public IMobileServiceTableQuery<T> Skip(int count)
        {
            return table.Skip(count);
        }

        public IMobileServiceTableQuery<T> Take(int count)
        {
            throw new NotImplementedException();
        }

        public IMobileServiceTableQuery<T> ThenBy<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            throw new NotImplementedException();
        }

        public IMobileServiceTableQuery<T> ThenByDescending<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> ToEnumerableAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> ToListAsync()
        {
            return table.ToListAsync();
        }

        public Task UndeleteAsync(T instance)
        {
            return table.UndeleteAsync(instance);
        }

        public Task UndeleteAsync(T instance, IDictionary<string, string> parameters)
        {
            return table.UndeleteAsync(instance, parameters);
        }

        public Task<JToken> UndeleteAsync(JObject instance)
        {
            return table.UndeleteAsync(instance);
        }

        public Task<JToken> UndeleteAsync(JObject instance, IDictionary<string, string> parameters)
        {
            return table.UndeleteAsync(instance, parameters);
        }

        public Task UpdateAsync(T instance)
        {
            return table.UpdateAsync(instance);
        }

        public Task UpdateAsync(T instance, IDictionary<string, string> parameters)
        {
            return table.UpdateAsync(instance, parameters);
        }

        public Task<JToken> UpdateAsync(JObject instance)
        {
            return table.UpdateAsync(instance);
        }

        public Task<JToken> UpdateAsync(JObject instance, IDictionary<string, string> parameters)
        {
            return table.UpdateAsync(instance, parameters);
        }

        public IMobileServiceTableQuery<T> Where(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public IMobileServiceTableQuery<T> WithParameters(IDictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }

        Task<JToken> IMobileServiceTable.LookupAsync(object id)
        {
            throw new NotImplementedException();
        }

        Task<JToken> IMobileServiceTable.LookupAsync(object id, IDictionary<string, string> parameters)
        {
            throw new NotImplementedException();
        }
    }
}
