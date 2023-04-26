namespace PI_SEC.Entities;

public partial class User
{
    public User user;
    public long Id { get; set; }

    public string UserName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public DateTime CreatedDate { get; set; }

    public long CreatedBy { get; set; }

    public DateTime? UpdateDate { get; set; }

    public long? UpdateBy { get; set; }

}
