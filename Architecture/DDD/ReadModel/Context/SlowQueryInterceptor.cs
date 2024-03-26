using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;

namespace ReadModel.Context;

public class SlowQueryInterceptor : DbCommandInterceptor
{
    private const int _slowQueryThreshold = 200;

    public override DbDataReader ReaderExecuted(
        DbCommand command,
        CommandExecutedEventData eventData,
        DbDataReader result)
    {
        if (eventData.Duration.TotalMicroseconds > _slowQueryThreshold)
        {
            Console.WriteLine($"Slow query ({eventData.Duration.TotalMilliseconds} ms): {command.CommandText}");
        }

        return base.ReaderExecuted(command, eventData, result);
    }
}
