namespace Components
{
    public interface INode
    {
        void accept(INodeVisitor visitor);

    }
}