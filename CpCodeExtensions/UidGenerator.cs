namespace cpGames.core;

public class UidGenerator
{
    #region Fields
    private static readonly Random RND = new();
    private readonly Random _rnd;
    protected readonly object _syncRoot = new();
    private readonly HashSet<long> _uids = new();
    #endregion

    #region Constructors
    public UidGenerator()
    {
        _rnd = RND;
    }

    public UidGenerator(int seed)
    {
        _rnd = new Random(seed);
    }
    #endregion

    #region Methods
    public long GenerateUid()
    {
        lock (_syncRoot)
        {
            long uid;
            do
            {
                uid = (long)(_rnd.NextDouble() * (long.MaxValue - 1)) + 1;
            } while (!_uids.Add(uid));

            return uid;
        }
    }

    public long GenerateUid(int offset)
    {
        lock (_syncRoot)
        {
            long uid;
            do
            {
                var max = Number.RemoveDigitsLeft(long.MaxValue, offset);
                uid = (long)(_rnd.NextDouble() * (max - 1)) + 1;
            } while (!_uids.Add(uid));

            return uid;
        }
    }

    public void RemoveUid(long uid)
    {
        lock (_syncRoot)
        {
            _uids.Remove(uid);
        }
    }

    public void AddUid(long uid)
    {
        lock (_syncRoot)
        {
            if (_uids.Contains(uid))
            {
                throw new Exception("Uid already exists");
            }
            _uids.Add(uid);
        }
    }

    public void Clear()
    {
        lock (_syncRoot)
        {
            _uids.Clear();
        }
    }

    public bool HasUid(long uid)
    {
        lock (_syncRoot)
        {
            return _uids.Contains(uid);
        }
    }
    #endregion
}