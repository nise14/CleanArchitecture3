namespace NorthWind.Presenters;

public interface IPresenter<FormatDatType>
{
    public FormatDatType Content { get; }
}