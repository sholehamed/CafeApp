namespace CafeApp.Business.Helpers.Dtos
{
    public class DashboardTableModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int Number { get; set; }
        public TableState State { get; set; }
        public DashboardFactorModel Factor { get; set; }=new DashboardFactorModel();
        public string LastConnectionId { get; set; }
        public TableState LastState { get; set; }
        public List<DashboardCategoryModel>? Categories { get; set; } = new List<DashboardCategoryModel>();
        public DashboardCategoryModel? SelectedCategory { get; set; } = new DashboardCategoryModel();
        public bool IsEditEnabled { get; set; }
    }
    public enum TableState
    {
        filled = 0,
        empty = 1,
        requesting = 2
    }
    public class DashboardFactorModel
    {
        public Guid Id { get; set; }
        public Guid TableId { get; set; }
        public string TableTitle { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string FactorNumber { get; set; }
        public DateTime Time { get; set; }
        public short Type { get; set; }
        public short State { get; set; }
        public string RecordDate { get; set; }
        public string RecordTime { get; set; }

        public long TotalPrice { get { return Items.Select(x => x.TotalPrice).Sum(); } }
        public long Paid { get; set; }
        public long Dongi { get { return Items.Select(x => x.UnitPrice * x.SubmittedDongi).Sum(); } }
        public ICollection<DashboardFactorItemModel> Items { get; set; }
        public string Description { get; set; }
        public DashboardFactorModel()
        {
            Items = new List<DashboardFactorItemModel>();
        }
    }
    public class DashboardFactorItemModel
    {
        public DashboardFactorItemModel()
        {
            Id=Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public Guid? CategoryId { get; set; }
        public Guid ProductId { get; set; }
        public string ProductTitle { get; set; }
        public int TotalAmount { get; set; }
        public int PaidAmount { get; set; }
        public long TotalPrice { get { return TotalAmount * UnitPrice; } }
        public long UnitPrice { get; set; }
        public string Description { get; set; }
        public string State { get; set; }
        public bool StateChecked { get; set; }
        public int SubmittedDongi { get; set; }
        public void SubmitDongi()
        {
            SubmittedDongi = PaidAmount;
        }

    }
    public class DashboardProductModel
    {
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public string Title { get; set; }
        public int Amount { get; set; }
        public long Price { get; set; }
    }
    public class DashboardCategoryModel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public List<DashboardProductModel> Items { get; set; }
        public DashboardCategoryModel()
        {
            Items = new List<DashboardProductModel>();
        }
    }
}
