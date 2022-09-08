class SubtractCommand : BaseBinaryCommand
{
    public SubtractCommand(int regNumberForResult) : base(regNumberForResult, "sub") { }

    protected override int ExecuteBinaryCommand(int left, int right)
    {
        return left - right;
    }
}
