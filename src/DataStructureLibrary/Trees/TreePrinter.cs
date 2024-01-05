namespace DataStructures.DataStructureLibrary.Trees;

public class TreePrinter
{
    public static string Print<T>(IEnumerable<T> treeValues)
    {
        var sb = new StringBuilder();
        sb.Append("[");

        foreach (var item in treeValues)
        {
            sb.Append(item);
            sb.Append(", ");
        }

        if (sb.Length > 2)
        {
            sb.Remove(sb.Length - 2, 2);
        }
        sb.Append("]");

        return sb.ToString();
    }
}