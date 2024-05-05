namespace Base.Contracts.DAL;

public interface IDalMapper<TLeftObject, TRightObject>
    where TLeftObject : class
    where TRightObject : class
{
    TLeftObject? MapRightLeft(TRightObject? inObject);
    TRightObject? MapLeftRight(TLeftObject? inObject);
}