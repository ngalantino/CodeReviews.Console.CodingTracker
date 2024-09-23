
public class CodingSession {
    public long Id {get; set;}

    public DateTime startTime {get; set;}

    public DateTime endTime {get; set;}

    public TimeSpan timeSpan {
        get {
            return this.endTime - this.startTime;
        }
    }

}