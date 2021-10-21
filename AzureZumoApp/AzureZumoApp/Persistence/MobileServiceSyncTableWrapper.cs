using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace AzureZumoApp.Persistence
{
    class MobileServiceSyncTableWrapper<T> : IMobileServiceSyncTable<T>
    {
        IMobileServiceSyncTable<T> table;
        MobileServiceClient _mobileServiceClient;

        public MobileServiceSyncTableWrapper(IMobileServiceClient mobileServiceClient)
        {
            _mobileServiceClient = (MobileServiceClient)mobileServiceClient;
            table = _mobileServiceClient.GetSyncTable<T>();
        }

        public MobileServiceClient MobileServiceClient => _mobileServiceClient;

        public string TableName => table.TableName;

        public MobileServiceRemoteTableOptions SupportedOptions { get => table.SupportedOptions; set { table.SupportedOptions = value; } }

        public IMobileServiceTableQuery<T> CreateQuery()
        {
            return table.CreateQuery();
        }

        public Task DeleteAsync(T instance)
        {
            return table.DeleteAsync(instance);
        }

        public Task DeleteAsync(JObject instance)
        {
            return table.DeleteAsync(instance);
        }

        public IMobileServiceTableQuery<T> IncludeTotalCount()
        {
            return table.IncludeTotalCount();
        }

        public Task InsertAsync(T instance)
        {
            return table.InsertAsync(instance);
        }

        public Task<JObject> InsertAsync(JObject instance)
        {
            return table.InsertAsync(instance);
        }

        public Task<T> LookupAsync(string id)
        {
            return table.LookupAsync(id);
        }

        public IMobileServiceTableQuery<T> OrderBy<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return table.OrderBy<TKey>(keySelector);
        }

        public IMobileServiceTableQuery<T> OrderByDescending<TKey>(Expression<Func<T, TKey>> keySelector)
        {
            return table.OrderByDescending<TKey>(keySelector);
        }

        public Task PullAsync<U>(string queryId, IMobileServiceTableQuery<U> query, bool pushOtherTables, CancellationToken cancellationToken, PullOptions pullOptions)
        {
            return table.PullAsync<U>(queryId, query, pushOtherTables, cancellationToken, pullOptions);
        }

        public Task PullAsync(string queryId, string query, IDictionary<string, string> parameters, bool pushOtherTables, CancellationToken cancellationToken, PullOptions pullOptions)
        {
            throw new NotImplementedException();
        }

        public Task PurgeAsync<U>(string queryId, IMobileServiceTableQuery<U> query, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task PurgeAsync<U>(string queryId, IMobileServiceTableQuery<U> query, bool force, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task PurgeAsync(string queryId, string query, bool force, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> ReadAsync()
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<U>> ReadAsync<U>(IMobileServiceTableQuery<U> query)
        {
            throw new NotImplementedException();
        }

        public Task<JToken> ReadAsync(string query)
        {
            throw new NotImplementedException();
        }

        public Task RefreshAsync(T instance)
        {
            throw new NotImplementedException();
        }

        public IMobileServiceTableQuery<U> Select<U>(Expression<Func<T, U>> selector)
        {
            throw new NotImplementedException();
        }

        public IMobileServiceTableQuery<T> Skip(int count)
        {
            throw new NotImplementedException();
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

        public Task UpdateAsync(T instance)
        {
            return table.UpdateAsync(instance);
        }

        public Task UpdateAsync(JObject instance)
        {
            return table.UpdateAsync(instance);
        }

        public IMobileServiceTableQuery<T> Where(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        Task<JObject> IMobileServiceSyncTable.LookupAsync(string id)
        {
            throw new NotImplementedException();
        }
    }
}
