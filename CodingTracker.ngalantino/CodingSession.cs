
public class CodingSession {
    public long Id {get; set;}

    public DateTime StartTime {get; set;}

    public DateTime EndTime {get; set;}

    public TimeSpan TimeSpan {
        get {
            return this.EndTime - this.StartTime;
        }
    }

}