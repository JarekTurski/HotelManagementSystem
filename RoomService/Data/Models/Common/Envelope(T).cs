namespace RoomService.Data.Models.Common;

public class Envelope<T> : Envelope
{
    public Envelope(T data) : base()
    {
        Data = data;
    }

    public Envelope(Error error) : base(error) 
    { 
    }

    public T Data { get; set; }
}
