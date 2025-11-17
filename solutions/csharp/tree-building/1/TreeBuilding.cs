public class TreeBuildingRecord
{
    public int ParentId { get; set; }
    public int RecordId { get; set; }

    public bool IsRoot => ParentId == RecordId;
}

public class Tree
{
    public int Id { get; set; }
    public int ParentId { get; set; }

    public List<Tree> Children { get; set; }

    public bool IsLeaf => Children.Count == 0;

    public Tree(int id) {
        Id = id;
        Children = new List<Tree>();
    }
}

public static class TreeBuilder
{
    private const int RootRecordId = 0;
    
    public static Tree BuildTree(IEnumerable<TreeBuildingRecord> records)
    {
        var ordered = GetOrderedRecords(records);
        if (!ordered.Any()) {
            throw new ArgumentException();
        }

        var nodes = new Dictionary<int, Tree>();
        var previousRecordId = -1;
        foreach (var record in ordered) {
            ValidateRecord(record, previousRecordId);

            nodes[record.RecordId] = new Tree(record.RecordId);
            if (!record.IsRoot) {
                nodes[record.ParentId].Children.Add(nodes[record.RecordId]);
            }

            previousRecordId++;
        }

        return nodes[RootRecordId];
    }

    private static void ValidateRecord(TreeBuildingRecord record, int previousRecordId) {
        if (record.IsRoot && record.ParentId != RootRecordId) {
            throw new ArgumentException();
        }
        else if (!record.IsRoot && record.ParentId >= record.RecordId) {
            throw new ArgumentException();
        }
        else if (!record.IsRoot && record.RecordId != previousRecordId + 1) {
            throw new ArgumentException();
        }
    }

    private static List<TreeBuildingRecord> GetOrderedRecords(IEnumerable<TreeBuildingRecord> records) => records.OrderBy(r => r.RecordId).ToList();
}