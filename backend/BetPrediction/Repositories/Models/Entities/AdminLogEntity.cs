namespace Repositories.Models.Entities;

public class AdminLogEntity : BaseEntity<Guid>
{
    public string UserName { get; set; }

    public string StartDate { get; set; }

    public string ActionName { get; set; }

    public DateTime StartPeriodDate { get; set; }

    public DateTime EndPeriodDate { get; set; }
}