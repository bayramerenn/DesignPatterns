using StackExchange.Redis.Extensions.Core;
using StackExchange.Redis.Extensions.Core.Configuration;
using StackExchange.Redis.Extensions.System.Text.Json;

namespace DecaratorPattern.Sample1
{
    public static class ConfigureService
    {
    //    public static IServiceCollection AddStackExchangeRedisExtensions<T>(this IServiceCollection services, RedisConfiguration redisConfiguration)
    //where T : class, ISerializer, new()
    //    {
    //       var config =  new RedisConfiguration()
    //        {
    //            AbortOnConnectFail = true,
    //            KeyPrefix = "_my_key_prefix_",
    //            Hosts = new RedisHost[]
    //                    {
    //                        new RedisHost(){Host = "localhost", Port = 6379},
    //                    },
    //            ServiceName = "my-sentinel", // In case you are using Sentinel
    //            AllowAdmin = true,
    //            ConnectTimeout = 3000,
    //            Database = 3,
    //            Ssl = true,
    //            Password = "my_super_secret_password",
    //            ServerEnumerationStrategy = new ServerEnumerationStrategy()
    //            {
    //                Mode = ServerEnumerationStrategy.ModeOptions.All,
    //                TargetRole = ServerEnumerationStrategy.TargetRoleOptions.Any,
    //                UnreachableServerAction = ServerEnumerationStrategy.UnreachableServerActionOptions.Throw
    //            },
    //            MaxValueLength = 1024,
    //            PoolSize = 2,
    //            Name = "My Secondary Connection"
    //        };

    //        services.AddStackExchangeRedisExtensions<SystemTextJsonSerializer>(redisConfiguration);
    //        return services;
    //    }
    }
}