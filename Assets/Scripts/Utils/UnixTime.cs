using System;

public static class UnixTime
{
    public static DateTime GetDatetime(long unixTimeStamp)
    {
        DateTime dateTime = new DateTime(1601, 1, 1, 4, 0, 0);
        dateTime = dateTime.AddTicks(unixTimeStamp);
        return dateTime;
    }

    public static long GetUnixTimestamp(DateTime? dateTime)
    {
        if (!dateTime.HasValue)
            return 0;

        var timespan = dateTime.Value - new DateTime(1601, 1, 1, 4, 0, 0);
        return timespan.Ticks;
    }
}