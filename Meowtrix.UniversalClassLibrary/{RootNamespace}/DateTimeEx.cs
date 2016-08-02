using System;

namespace Meowtrix
{
    /// <summary>
    /// Provides extension methods for <see cref="DateTime"/> and <see cref="DateTimeOffset"/>.
    /// </summary>
    public static class DateTimeEx
    {
        /// <summary>
        /// Get remaining time from now to a <see cref="DateTimeOffset"/>.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>Remaining time from now to <paramref name="time"/>.</returns>
        public static TimeSpan Remain(this DateTimeOffset time) => time.ToLocalTime() > DateTimeOffset.Now ? time - DateTimeOffset.Now : new TimeSpan(0);

        /// <summary>
        /// Get during time from a <see cref="DateTimeOffset"/> to now.
        /// </summary>
        /// <param name="time">The time.</param>
        /// <returns>Remaining time from <paramref name="time"/> to now.</returns>
        public static TimeSpan During(this DateTimeOffset time) => time.ToLocalTime() < DateTimeOffset.Now ? DateTimeOffset.Now - time : new TimeSpan(0);
    }
}
