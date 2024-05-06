namespace BLL.ModelViews
{
    public class TaskMV
    {
        public int TaskId { get; set; }

        public int? ProjectId { get; set; }

        public string? Description { get; set; }

        public bool? IsComplete { get; set; }

    }
}
