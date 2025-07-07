using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MTHCollection.Models;
using SqlSugar;

namespace MTHCollection.DAL
{
    public class BaseSQLService
    {
        private static readonly Lazy<SqlSugarClient> sqliteLazy = new Lazy<SqlSugarClient>(() =>
        {
            var client = new SqlSugarClient(
                new ConnectionConfig
                {
                    // 配置数据库连接字符串，根据实际情况修改
                    ConnectionString = @"Data Source=MTHCollectionSystem.db",
                    DbType = DbType.Sqlite,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute // 从特性读取主键和自增列信息
                }
            );

            // 调式代码用来打印 SQL 语句
            client.Aop.OnLogExecuting = (sql, pars) =>
            {
                System.Diagnostics.Trace.WriteLine(
                    $"Sql：{sql} 参数值：{client.Utilities.SerializeObject(pars.ToDictionary(it => it.ParameterName, it => it.Value))}"
                );
            };
            client.CodeFirst.InitTables(
                new Type[]
                {
                    typeof(UserModel),
                    typeof(AlarmModel),
                    typeof(RealTimeDataModel),
                }
            );
            return client;
        });

        public static SqlSugarClient Sqlite => sqliteLazy.Value;
    }
}
