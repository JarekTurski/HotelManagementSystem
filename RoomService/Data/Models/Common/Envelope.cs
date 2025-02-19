namespace RoomService.Data.Models.Common;

public class Envelope
{
    public Envelope()
    {
        Errors = new List<Error>();
    }

    public Envelope(Error error)
    {
        if(error is null)
        {
            throw new ArgumentNullException(nameof(error));
        }
        Errors = new List<Error>();
    }

    public IList<Error> Errors { get; }

    public bool HasErrors => Errors.Count > 0;
}
