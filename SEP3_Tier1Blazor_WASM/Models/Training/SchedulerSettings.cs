namespace SEP3_Tier1Blazor_WASM.Models.Training
{
    /// <summary>
    /// Class for storing an scheduler data
    /// </summary>
    public class SchedulerSettings
    {
        public int StartHour { get; set; }
        public int EndHour { get; set; }
        public int DaysInWeek { get; set; }
    }
}